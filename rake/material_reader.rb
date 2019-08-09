require 'yaml'
require 'pp'
require 'colorize'
require 'psych'

class MaterialReader
  attr_accessor :material
  attr_accessor :properties
  attr_accessor :floats
  attr_accessor :tex_envs
  attr_accessor :colors
  attr_accessor :vectors
  attr_accessor :header
  attr_accessor :name

  def initialize(content, name = nil)
    self.name = name
    self.floats = {}
    self.tex_envs = {}
    self.colors = {}
    self.vectors = {}

    self.material = YAML.load(content)['Material']
    self.properties = self.material['m_SavedProperties']

    if name == 'male101_npc053_face'
      # puts self.properties
      # puts content
    end

    self.properties['m_Floats'].each do |o|
      if o.is_a?(::Array)
        o = o[1]
      end

      o = o['data'] if o['data']

      k = o['first']['name']
      v = o['second']

      self.floats[k] = v
    end

    self.properties['m_Colors'].each do |o|
      o = o[1] if o.is_a?(::Array)
      next unless o
      o = o['data'] if o['data']
      self.colors[o['first']['name']] = o['second']
    end

    self.properties['m_TexEnvs'].each do |o|
      o = o[1] if o.is_a?(::Array)
      next unless o
      o = o['data'] if o['data']
      self.tex_envs[o['first']['name']] = o['second']
    end
  end

  def get_float(name)
    return self.floats[name]
  end

  def get_color(name)
    return self.colors[name]
  end

  def get_texture(name)
    return self.tex_envs[name]
  end

end