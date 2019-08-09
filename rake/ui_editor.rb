require 'yaml'
require 'pp'
require 'colorize'
require 'psych'
require_relative 'prefab_editor'

class UIEditor < PrefabEditor
  attr_accessor :bindable_nodes
  attr_accessor :path
  attr_accessor :node_paths
  attr_accessor :path_names
  attr_accessor :name2paths
  attr_accessor :buttons
  attr_accessor :button_names
  attr_accessor :texts
  attr_accessor :text_names

  def initialize(path, content)
    self.path = path
    self.bindable_nodes = {}
    self.node_paths = {}
    self.path_names = {}
    self.name2paths = {}
    self.buttons = {}
    self.button_names = {}
    self.texts = {}
    self.text_names = {}

    super(content)
    scan_all_bindable
    evaluate_paths
    evaluate_path_levels
  end

  def scan_gameobject_and_transforms()
    @gos2trans = {}
    @gos2comps = {}
    @trans2gos = {}
    @trans2children = {}
    @trans2father = {}
    @gos2names = {}
    @buttons = {}

    each_chunk_ext('GameObject') do |header, chunk, index|
      mres = chunk.match(/- 4: {fileID: (\d+)}/)
      trans_id = mres && mres.captures[0]

      if trans_id.nil?
        mres = chunk.match(/- 224: {fileID: (\d+)}/)
        trans_id = mres && mres.captures[0]
      end

      if trans_id.nil?
        mres = chunk.match(/- component: {fileID: (\d+)}/)
        trans_id = mres && mres.captures[0]
      end

      next unless trans_id
      go_id = get_id_from_header(header)
      @gos2trans[go_id] = trans_id
      @trans2gos[trans_id] = go_id

      mres = chunk.match(/m_Name: (.+)$/)
      go_name = mres && mres.captures[0]
      # puts ">>>>mres:#{mres}"
      if go_name
        # puts ">>>>go_name:#{go_name}"
        @gos2names[go_id] = go_name.gsub("'", '')
      end

      chunk.scan(/- (\d+): {fileID: (\d+)}/) do |sres|
        comp_id = sres[1]
        # puts "comp_id: #{comp_id}"
        @gos2comps[go_id] ||= {}
        @gos2comps[go_id][comp_id] = true
      end
    end

    each_chunk_ext('MonoBehaviour') do |header, chunk, index|
      if chunk.match(/m_TypeName: UnityEngine.UI.Toggle/)
        mres = chunk.match(/m_GameObject: {fileID: (\d+)}/)
        go_id = mres && mres.captures[0]
        @buttons[go_id] = true
      end

      if chunk.match(/m_TypeName: UnityEngine.UI.Button/)
        mres = chunk.match(/m_GameObject: {fileID: (\d+)}/)
        go_id = mres && mres.captures[0]
        @buttons[go_id] = true
      end

      if chunk.match(/m_Text: str_/)
        mres = chunk.match(/m_GameObject: {fileID: (\d+)}/)
        go_id = mres && mres.captures[0]
        @texts[go_id] = true
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

    each_chunk_ext('RectTransform') do |header, chunk, index|
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

  def scan_all_bindable
    each_chunk_ext('GameObject') do |header, chunk, index|
      mres = chunk.match(/m_Name: (.+)$/)
      go_name = mres && mres.captures[0]
      next if go_name.nil?

      go_id = get_id_from_header(header)

      if go_name[/^b_/]
        fathers = get_accesstors(go_id)
        @bindable_nodes[go_id] = {'name' => gos2names[go_id], 'fathers' => fathers}
        @node_paths[go_id] = get_path(go_id)
      end
    end
  end

  def get_accesstors(go_id)
    trans_id = @gos2trans[go_id]
    accestors = []
    get_fathers(trans_id, accestors)
    fathers = []

    accestors.each do |trans_id|
      go_id1 = @trans2gos[trans_id]
      name = @gos2names[go_id1]
      if name then
        fathers << {'id' => go_id1, 'name' => name, 'level' => fathers.length}
      end
    end
    fathers
  end

  def get_path(go_id, fathers = nil)
    fathers ||= get_accesstors(go_id)
    # puts ">>>>fathers:#{fathers} @gos2names:#{@gos2names}"
    fathers.delete_at(0)

    names = fathers.map {|x| x['name']}
    names << @gos2names[go_id]

    path = names.join('/')
  end

  def evaluate_path_levels
    bindable_nodes.each do |go_id, data|
      fathers = data['fathers'].clone
      bindable_fathers = fathers.select {|x| x['name'] =~ /^b_/ }

      level = 1
      bindable_fathers.each do |o|
        fathers = data['fathers'].clone
        o['level'].times do
          fathers.delete_at(0)
        end

        path = get_path(go_id, fathers)
        evaluate_path(go_id, path, path_names[o['id']]['$root'], level)
        level += 1
        break if level >= 2
      end
    end
  end

  def evaluate_paths
    node_paths.each do |go_id, path|
      evaluate_path(go_id, path, '$root')
    end
  end

  def evaluate_path(go_id, path, ref_root, level = 0)
    fathers = path.split('/')
    names = []
    fathers.each do |name|
      if name[/^b_(\w+)/]
        names << $1
      end
    end

    path_name = names.join('_')
    path_names[go_id] ||= {}
    path_names[go_id][ref_root] = path_name
    root_path = path_names[go_id]['$root']

    name2paths[ref_root] ||= {}

    name2paths[ref_root]['__buttons__'] ||= {}

    name2paths[ref_root][path_name]
    name2paths[ref_root][path_name] = path

    if buttons[go_id]
      if path_name 
        first = path_name[0]
        capital = first.upcase
        callback = path_name[0..-1]
        callback[0] = capital
        name2paths[ref_root]['__buttons__'][path_name] = "on#{callback}"
      end
    end

    if texts[go_id]
      name2paths[ref_root]['__buttons__'][path_name] = true
    end

    if path_name == 'bind' || path_name == 'new' then
      name2paths[ref_root]['__buttons__'][path_name] = true
    end
  end

  def to_hash
    index = path.index('prefab')
    p = path[index..-1].downcase
    p.gsub!('.prefab', '')
    hash = {
      p => name2paths
    }
    hash
  end

  def dump

    puts "path_names: \n #{JSON.pretty_generate(to_hash)}"
  end
end