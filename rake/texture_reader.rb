require 'yaml'
require 'pp'
require 'colorize'
require 'psych'

class TextureReader
  attr_accessor :content
  attr_accessor :meta_path
  attr_accessor :path
  attr_accessor :width
  attr_accessor :height
  attr_accessor :o

  def initialize(path)
    self.path = path
    self.meta_path = "#{path}.meta"

    if File.exist?(meta_path)
      self.content = IO.read(meta_path)
    end
  end

  def set_ios_format(new_format)
    return unless content

    self.o = self.o || YAML.load(self.content)
    changed = false

    if o['TextureImporter']['buildTargetSettings']
      settings = o['TextureImporter']['buildTargetSettings']
      settings.each do |setting|
        if setting['buildTarget'] == 'iPhone'
          old_format = setting['textureFormat']
          puts old_format
          if old_format != new_format
            setting['textureFormat'] = new_format
            changed = true
          end
        end
      end
    end

    IO.write(self.meta_path, o.to_yaml) if changed
  end

  def simple_path
    index = self.path.index('Assets')
    self.path[index..-1]
  end

  def w
    calc_size unless width
    width
  end

  def h
    calc_size unless height
    height
  end

  def none_square?
    h != w
  end

  def calc_size
    res = `identify "#{path}"`
    # puts ">>> file:#{file} res:#{res}"
    # [res[0], res[1]]
    size = res.split(' ')[2]
    width, height = size.split('x').map(&:to_i)
    self.width = width
    self.height = height
  end

  def to_size_hash
    o = {}
    o['path'] = simple_path
    o['w'] = w
    o['h'] = h
    o
  end
end
