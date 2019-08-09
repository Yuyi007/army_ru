require_relative 'prefab_editor'

class EfxLodEditor < PrefabEditor

  # low   -   delete lod1 and lod2
  # mid   -   delete lod2
  # high  -   no deletions

  attr_accessor :lod1_deletions
  attr_accessor :lod2_deletions

  def initialize(content)
    super(content)
    scan_all_lods_deletions()
  end

  def scan_all_lods_deletions()
    @lod1_deletions = {}
    @lod2_deletions = {}

    each_chunk_ext('GameObject') do |header, chunk, index|
      mres = chunk.match(/m_Name: (.+)$/)
      go_name = mres && mres.captures[0]
      next if go_name.nil?

      go_id = get_id_from_header(header)
      if go_name[/_lod2$/] || go_name[/_lod2 +$/]
        @lod2_deletions[go_id] = true
      end

      if go_name[/_lod1$/] || go_name[/_lod1 +$/]
        @lod1_deletions[go_id] = true
      end
    end
  end

  def get_lod_files_contents()
    full_content = @content.dup

    # prepare mid version
    @lod2_deletions.each_pair do |go_id, val|
      trans_id = @gos2trans[go_id]
      remove_gameobject_by_trans_id(trans_id)
    end

    # puts "lod2_deletions=#{lod2_deletions}"
    # puts "lod1_deletions=#{lod1_deletions}"

    mid_content = nil

    unless @lod2_deletions.empty?
      mid_content = @content.dup
    end

    @lod1_deletions.each_pair do |go_id, val|
      trans_id = @gos2trans[go_id]
      remove_gameobject_by_trans_id(trans_id)
    end

    low_content = nil

    unless @lod1_deletions.empty?
      low_content = @content.dup
    end

    return full_content, mid_content, low_content
  end

end