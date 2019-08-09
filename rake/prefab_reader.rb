require 'yaml'
require 'pp'
require 'colorize'
require 'psych'

class PrefabReader

  attr_accessor :content
  attr_accessor :chunks
  attr_accessor :headers

  def initialize(content)
    self.content = content
    self.headers = content.scan(/--- .+/)
    self.chunks = content.split(/--- .+/)
  end

  def each_object(type)
    each_chunk(type) do |chunk, index|
      o = YAML.load(chunk)
      c = o[type]
      yield(c, chunk, index)
    end
  end

  def find_bone_name(fileID)
    each_chunk('GameObject') do |chunk, _|
      if chunk.scan(/- 4: {fileID: #{fileID}}/).flatten.size > 0
        o = YAML.load(chunk)
        return o['GameObject']['m_Name']
      end
    end

    return nil
  end

  def find_root_game_object
    fileID = nil
    each_object('Prefab') do |o, chunk, index|
      fileID = o['m_RootGameObject']['fileID']
    end

    return fileID
  end

  def each_chunk(type)
    self.chunks.each_with_index do |chunk, index|
      next unless index > 0
      next unless chunk =~ /^#{type}:/
      yield(chunk, index)
    end
  end

  def each_chunk_ext(type)
    self.chunks.each_with_index do |chunk, index|
      next unless index > 0
      next unless chunk =~ /^#{type}:/
      header = headers[index - 1]
      yield(header, chunk, index)
    end
  end

  def modify_inplace(&blk)
    lines = []
    lines << chunks[0]
    chunks.each_with_index do |chunk, index|
      next if index == 0
      lines << headers[index - 1]
      chunks[index] = yield(chunk)
      lines << chunks[index]
    end
    self.content = lines.join('')
  end

  def modify_inplace_ext(&blk)
    lines = []
    lines << chunks[0]

    remove_idx = []

    chunks.each_with_index do |chunk, index|
      next if index == 0
      header = headers[index - 1]
      headers[index - 1], chunks[index] = yield(header, chunk, index)
      lines << headers[index - 1]
      lines << chunks[index]
    end

    self.content = lines.join('')
  end

  def find_chunks(type)
    list = []
    each_object(type) do |o, chunk, index|
      res = {}
      res['o'] = o
      res['chunk'] = chunk
      res['index'] = index
      list << res
    end

    list
  end

  def devide_string(chunk, regexVal)
    positions = chunk.enum_for(:scan, regexVal).map { Regexp.last_match.begin(0) }

    if positions.size == 0
      return [chunk]
    elsif positions.size == 1
      return [
        chunk[0 .. (positions[0]-1)],
        chunk[positions[0] .. (-1)],
      ]
    end

    sub_chunks = []
    idx = positions[0]
    idx2 = positions[1]

    sub_chunks << chunk[0 .. (idx-1)]
    (0..(positions.size-2)).each do |x|
      idx = positions[x]
      idx2 = positions[x+1]
      sub_chunks << chunk[idx..(idx2-1)]
    end
    sub_chunks << chunk[idx2 .. (-1)]
    return sub_chunks
  end

end