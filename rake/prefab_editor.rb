require_relative 'prefab_reader'

class PrefabEditor < PrefabReader

  attr_accessor :gos2trans
  attr_accessor :gos2names
  attr_accessor :gos2comps
  attr_accessor :trans2gos
  attr_accessor :trans2children
  attr_accessor :trans2father

  def initialize(content)
    super(content)
    scan_gameobject_and_transforms()
  end

  def get_id_from_header(header)
    header.split('&')[1]
  end

  def get_trans_name(trans_id)
    go_id = trans2gos[trans_id]
    gos2names[go_id]
  end

  def get_go_name(go_id)
    gos2names[go_id]
  end

  def get_go_trans(go_id)
    gos2trans[go_id]
  end

  def has_bone?(name)
    gos2names.any? {|go_id, go_name| go_name == name}
  end

  def scan_gameobject_and_transforms()
    @gos2trans = {}
    @gos2comps = {}
    @trans2gos = {}
    @trans2children = {}
    @trans2father = {}
    @gos2names = {}

    each_chunk_ext('GameObject') do |header, chunk, index|
      mres = chunk.match(/- component: {fileID: (\d+)}/)
      trans_id = mres && mres.captures[0]
      next unless trans_id
      go_id = get_id_from_header(header)
      @gos2trans[go_id] = trans_id
      @trans2gos[trans_id] = go_id

      mres = chunk.match(/m_Name: (.+)$/)
      go_name = mres && mres.captures[0]

      if go_name
        @gos2names[go_id] = go_name.gsub("'", '')
      end

      chunk.scan(/- (\d+): {fileID: (\d+)}/) do |sres|
        comp_id = sres[1]
        # puts "comp_id: #{comp_id}"
        @gos2comps[go_id] ||= {}
        @gos2comps[go_id][comp_id] = true
      end
    end

    each_chunk_ext('Transform') do |header, chunk, index|
      trans_id = get_id_from_header(header)
      chunk.scan(/- {fileID: (\d+)}/) do |sres|
        child_trans_id = sres[0]
        @trans2children[trans_id] ||= {}
        @trans2children[trans_id][child_trans_id] = true
      end

      mres = chunk.match(/m_Father: {fileID: (\d+)}/)
      if mres and mres.captures[0]
        @trans2father[trans_id] = mres.captures[0]
      end
    end
  end

  def find_gameobject_ids_by_name(go_name)
    res = []
    each_chunk_ext('GameObject') do |header, chunk, index|
      if chunk[/m_Name: #{go_name}$/]
        go_id = get_id_from_header(header)
        res << go_id if go_id
      end
    end
    return res
  end

  def get_fathers(trans_id, fathers = [])
    father_trans_id = @trans2father[trans_id]
    if father_trans_id
      fathers.unshift(father_trans_id)
      get_fathers(father_trans_id, fathers)
    end
  end

  def get_path(trans_id)
    fathers = []
    go_name = get_trans_name(trans_id)
    get_fathers(trans_id, fathers)
    fathers = fathers.map {|x| get_trans_name(x)}
    fathers.delete(nil)
    fathers.delete_at(0)
    fathers << go_name
    fathers.join('/')
  end

  def remove_gameobject_by_trans_id(trans_id)
    # 1. find game object referencing this transform id
    go_id = @trans2gos[trans_id]

    all_comps_ids = @gos2comps[go_id]
    father_trans_id = @trans2father[trans_id]
    child_trans_ids = @trans2children[trans_id]

    # 2. remove reference in parent transform
    if father_trans_id
      remove_child_id_from_trans_id(father_trans_id, trans_id)
    end
    

    # 3. remove children transforms (recursively call step 1)
    if child_trans_ids
      child_trans_ids.each_pair do |cti, val|
        remove_gameobject_by_trans_id(cti)
      end
    end

    if all_comps_ids
      # 4. remove all the other components (except transform) for this game object
      remove_comps_by_comps_ids(all_comps_ids)

      # 5. remove all the other components from subemitter module
      try_remove_sub_emitter_id_in_by_comp_id(all_comps_ids)
    else
      puts "#{go_id}, #{trans_id}, has no all_comps_ids???"
    end

    # 6. remove game object
    remove_gameobject(go_id)
  end

  def remove_gameobject(go_id)
    modify_inplace_ext do |header, chunk, index|
      cur_go_id = get_id_from_header(header)
      if go_id == cur_go_id
        next '', ''
      else
        next header, chunk
      end
    end
  end

  def remove_comps_by_comps_ids(all_comps_ids)
    modify_inplace_ext do |header, chunk, index|
      comp_id = get_id_from_header(header)
      if all_comps_ids[comp_id]
        next '', ''
      else
        next header, chunk
      end
    end
  end

  def remove_child_id_from_trans_id(father_trans_id, child_trans_id)
    child_trans_ids = @trans2children[father_trans_id]
    modify_inplace_ext do |header, chunk, index|
      if header[father_trans_id]
        sub_chunks = devide_string(chunk, /^  \w/)
        sub_chunks.each_with_index do |sc, index1|
          if sc['m_Children:']
            child_states = devide_string(sc, /^  \-/)
            child_states.each_with_index do |cs, index2|
              if cs[child_trans_id]
                child_states[index2] = ''
              end
            end
            sub_chunks[index1] = child_states.join('')
          end
        end
        next header, sub_chunks.join('')
      else
        next header, chunk
      end
    end
  end

  def try_remove_sub_emitter_id_in_by_comp_id(all_comps_ids)
    modify_inplace_ext do |header, chunk, index|
      if chunk['ParticleSystem:']
        sub_chunks = devide_string(chunk, /^  \w/)
        sub_chunks.each_with_index do |sc, index1|
          if sc['SubModule:']
            child_states = devide_string(sc, /^    \w/)
            child_states.each_with_index do |cs, index2|
              cs.scan(/    \w+: {fileID: (\d+)}/) do |sres|
                comp_id = sres[0]
                if all_comps_ids[comp_id]
                  child_states[index2] = cs.gsub(comp_id, '0')
                end
              end
            end
            sub_chunks[index1] = child_states.join('')
          end
        end
        next header, sub_chunks.join('')
      else
        next header, chunk
      end
    end
  end

  def remove_all_child_ids_from_trans_id(father_trans_id)
    child_trans_ids = @trans2children[father_trans_id]
    modify_inplace_ext do |header, chunk, index|
      if header[father_trans_id]
        sub_chunks = devide_string(chunk, /^  \w/)
        sub_chunks.each_with_index do |sc, index1|
          if sc['m_Children:']
            child_states = devide_string(sc, /^  \-/)
            child_states.each_with_index do |cs, index2|
              mres = cs.match(/- {fileID: (\d+)}/)
              if mres && mres.captures[0] && child_trans_ids[mres.captures[0]]
                child_states[index2] = ''
              end
            end
            sub_chunks[index1] = child_states.join('')
          end
        end
        next header, sub_chunks.join('')
      else
        next header, chunk
      end
    end
  end


end