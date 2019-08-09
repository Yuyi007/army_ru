
require 'yaml'
require 'pp'
require 'colorize'
require 'psych'
require 'digest'
require_relative 'prefab_reader'
require_relative 'material_reader'
require_relative 'texture_reader'
require_relative 'animator_editor'
require_relative 'animators_stripper'
require_relative 'efx_lod_stripper'
require_relative 'ui_editor'

# require 'mini_magick'

def build_bundle(buildPath, target)
  puts "Building bundle for #{target}, buildPath=#{buildPath}"
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -buildTarget #{target} -batchmode -quit -executeMethod Packager.MakeBundlesCmd #{buildPath} #{target} -logFile ")
end

def reimport(target)
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -buildTarget #{target} -batchmode -quit -executeMethod Packager.MakeEmpty -logFile ")
end

def reimport_modelstreets(target)
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -buildTarget #{target} -batchmode -quit -executeMethod ModelEditorHelper.ReimportAllModelsInModelsStreets -logFile ")
end

def bootstrap
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -batchmode -quit -executeMethod Packager.Bootstrap -logFile ")
end

def ms_controllers
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -batchmode -quit -executeMethod Packager.BootstrapMainsceneControllers -logFile ")
end

def bootstrap_sprite_assets
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -batchmode -quit -executeMethod Packager.BootstrapSpriteAssets -logFile ")
end

def bootstrap_combat_particles
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -batchmode -quit -executeMethod Packager.BootstrapCombatParticles -logFile ")
end

def fix_controllers
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -batchmode -quit -executeMethod ModelEditorHelper.FixAllControllers -logFile ")
end

def proj_root
  Boot::Tools.config.project_root
end

def unity_dir2
  Boot::Tools.config.project_root
end  

def bundle_root(platform)
  if platform == 'ios'
    Boot::Tools.config.ios_bundle_root
  elsif platform == 'osx'
    Boot::Tools.config.osx_bundle_root
  else
    Boot::Tools.config.android_bundle_root
  end
end

def write_ui_info(bundle_root = nil)
  scan_ui(bundle_root)
end

def scan_ui(bundle_root = nil)
  count = 0
  files = get_asset_files('prefab/ui/**/*.prefab')
  puts "scan ui files:#{files}"
  hash = {}
  files.each do |file|
    uiEditor = UIEditor.new(file, IO.read(file))
    hash.merge!(uiEditor.to_hash)
  end

  keys = hash.keys.sort
  h = {}
  keys.each do |key|
    h[key] = hash[key]
  end

  hash = h

  varnames = hash.values.map {|o| o.values.map {|x| x.keys}}.flatten
  varnames |= varnames
  varnames.sort!
  varnames = ::Hash[varnames.map {|x| [x, true]}]
  varnames.delete('__buttons__')

  file = "#{unity_dir}/Assets/StreamingAssets/uimapper.json"
  file2 = "#{unity_dir}/Assets/StreamingAssets/uivarnames.json"

  IO.write(file, JSON.pretty_generate(hash))
  IO.write(file2, JSON.pretty_generate(varnames))

  if bundle_root
    merge(jsonFiles: [file, file2],
          folder: "#{bundle_root}/")
  else
    merge(jsonFiles: [file, file2],
          folder: "#{unity_dir}/Assets/StreamingAssets/")
  end
end


def write_particle_info(bundle_root = nil)
  files = get_asset_files('Prefab/misc/**/*.prefab')
  particles = {}
  
  puts ">>>>enter555:#{files}"
  files.each do |file|
    puts ">>>>enter666:#{file}"
    length = 0
    str = IO.read(file)
    reader = PrefabReader.new(str)
    name = File.basename(file, '.prefab')
    index = file.index('Prefab')
    path = file[index..-1]
    folder = File.dirname(path)
    path.gsub!('.prefab', '')
    has_animator = str.scan(/Animator:/).size > 0

    length = str.scan(/lengthInSec: (.+)/).flatten.map {|x| x.to_f}.max
    duration = str.scan(/duration: (.+)/).flatten.map {|x| x.to_f}.max

    o = {}
    o['system_duration'] = length || 0
    o['stored_duration'] = duration if duration && duration > 0

    if has_animator
      real_animator = false
      reader.each_chunk('Animator') do |chunk, index|
        if chunk.scan(/m_Controller: {fileID: 0}/).size > 0
        else
          real_animator = true
          break
        end
      end
    end

    if real_animator
      o['has_animator'] = real_animator
    end

    path = path.downcase
    folder = folder.downcase
    name = name.downcase

    particles[path.downcase] = o
  end

  json_file = "#{unity_dir}/Assets/StreamingAssets/particles_duration.json"
  IO.write(json_file, JSON.pretty_generate(particles))

  if bundle_root
    merge(jsonFiles: [json_file], folder: "#{bundle_root}/")
  else
    merge(jsonFiles: [json_file], folder: "#{unity_dir}/Assets/StreamingAssets/")
  end
end

def downscale_variant_textures(folder)
  image_files = FileList["#{unity_dir}/temp_textures/#{folder}/**/*.tga", "#{unity_dir}/temp_textures/#{folder}/**/*.TGA"]
  image_files.uniq!
  image_files = image_files.map { |x| "'#{x}'" }
  puts "downscaling variant textures for #{folder} num=#{image_files.size}...please wait"

  image_files.each_slice(500) do |files|
    puts 'morifying..'
    system(%{
      if ! [ -x "$(command -v mogrify)" ]; then
        echo 'installing imagemagick'
        brew install imagemagick
      fi
    })
    system("mogrify -resize 50% #{files.join(' ')}")
  end
end

def fix_efx_bundle
  files = FileList["#{unity_dir}/Assets/Particles/effects/**/*.meta"]
  files.each do |file|
    content = IO.read(file)

    name = File.basename(file)
    arr = name.split('.')
    next if arr.size == 2
    name = name.split('.').first
    if name =~ /^ui/
      content.gsub!(/assetBundleName: .+/, 'assetBundleName: particles/effects/ui_materials.ab')
    else
      content.gsub!(/assetBundleName: .+/, 'assetBundleName:')
    end

    IO.write(file, content)
  end
end

def fix_image_metas
  files = FileList[
    "#{unity_dir}/Assets/images/ui/*.png.meta",
    "#{unity_dir}/Assets/images/icons/*.png.meta",
  ]

  files.each do |file|
    content = IO.read(file)
    lines = IO.readlines(file)
    lines.delete_if {|line| line.scan(/^  allowsAlphaSplitting/).flatten.size > 0}
    IO.write(file, lines.join(''))
  end
end

def find_unused_efx_asset
  prefab_depends = JSON.parse(IO.read("#{unity_dir}/prefab_depends.json"))
  efx_depends = []
  prefab_depends.each do |asset, depends|
    efx_depends |= depends if asset['Particles']
  end

  files = FileList["#{unity_dir}/Assets/Particles/effects/**/*.*"]
  files.exclude('.meta')

  files.each do |file|
  end
end

def find_unused_animations
  pd_str = IO.read("#{unity_dir}/animator_depends.json")

  suspect_anims = {
    'daoshi001_atk_kic11' => true,
    'daoshi001_atk_kic12_sword' => true,
    'daoshi001_atk_kic21_sword' => true,
    'daoshi001_atk_kic33_sword' => true,
    'daoshi001_atk_kic11_paper' => true,
    'daoshi001_atk_kic22_sword' => true,
    'daoshi001_atk_kic11_sword' => true,
    'daoshi001_atk_kic13_paper' => true,
    'daoshi001_atk_kic23_sword' => true,
    'daoshi001_atk_kic12' => true,
    'daoshi001_atk_kic13_sword' => true,
    'daoshi001_atk_kic31_sword' => true,
    'daoshi001_atk_kic12_paper' => true,
    'daoshi001_atk_kic32_sword' => true,
  }

  used_anims = []
  suspect_anims.each_pair do |aname, val|
    if pd_str["#{aname}.anim"]
      used_anims << aname
    end
  end
  puts "used_anims: #{used_anims}"
end

def get_asset_files(pattern)
  FileList["#{unity_dir}/Assets/#{pattern}"]
end

def fix_anim_settings
  files = FileList["#{unity_dir}/Assets/Model/animations/**/*.anim"]
  loop_clips = JSON.parse(IO.read("#{unity_dir}/loop_clips.json"))
  files.each do |file|
    # puts file
    name = File.basename(file, '.anim')
    if loop_clips[name] && !name['atk']
      content = IO.read(file)
      content.gsub!(/m_LoopTime: 0/, 'm_LoopTime: 1')
      IO.write(file, content)
    end
  end
end

def fix_prefab_settings
  fix_anim_settings

  files = FileList["#{unity_dir}/Assets/Particles/effects/**/*.tga.meta",
                   "#{unity_dir}/Assets/Particles/effects/**/*.TGA.meta",
                   "#{unity_dir}/Assets/Particles/effects/**/*.png.meta"]

  files.uniq!

  files.each do |file|
    content = IO.read(file)
    content.gsub!(/maxTextureSize: \d+/, 'maxTextureSize: 256')
    content.gsub!(/isReadable: 1/, 'isReadable: 0')
    content.gsub!(/enableMipMap: 1/, 'enableMipMap: 0')
    content.gsub!(/nPOTScale: 0/, 'nPOTScale: 3')

    IO.write(file, content)
  end

  files = FileList[
    "#{unity_dir}/Assets/Model/**/*.tga.meta",
    "#{unity_dir}/Assets/Model/**/*.TGA.meta",
    "#{unity_dir}/Assets/images/**/*.png.meta",
  ]
  files.uniq!

  files.each do |file|
    content = IO.read(file)
    content.gsub!(/isReadable: 1/, 'isReadable: 0')
    content.gsub!(/enableMipMap: 1/, 'enableMipMap: 0')
    IO.write(file, content)
  end

  files = FileList["#{unity_dir}/Assets/Prefab/**/*.prefab"]

  files.each do |file|
    content = IO.read(file)
    content.gsub!(/m_CastShadows: 1/, 'm_CastShadows: 0')
    content.gsub!(/m_ReceiveShadows: 1/, 'm_ReceiveShadows: 0')
    content.gsub!(/m_MotionVectors: 1/, 'm_MotionVectors: 0')
    content.gsub!(/m_LightProbeUsage: 1/, 'm_LightProbeUsage: 0')
    content.gsub!(/m_ReflectionProbeUsage: 1/, 'm_ReflectionProbeUsage: 0')
    content.gsub!(/maxNumParticles: 1000/, 'maxNumParticles: 100')

    IO.write(file, content)
  end

  files = FileList[
    "#{unity_dir}/Assets/Prefab/misc/**/*.prefab",
  ]

  sorting_layer_ui = '598224735'
  files.each do |file|
    content = IO.read(file)
    content.gsub!(/m_SortingLayerID: \d+/, "m_SortingLayerID: #{sorting_layer_ui}")

    IO.write(file, content)
  end


  files = FileList[
    "#{unity_dir}/Assets/Particles/**/*.FBX.meta",
    "#{unity_dir}/Assets/Particles/**/*.fbx.meta",
    "#{unity_dir}/Assets/Entity/**/*.FBX.meta",
    "#{unity_dir}/Assets/Entity/**/*.fbx.meta",
    "#{unity_dir}/Assets/Scenes/**/*.FBX.meta",
    "#{unity_dir}/Assets/Scenes/**/*.fbx.meta",
  ]
  files.uniq!

  files.each do |file|
    content = IO.read(file)
    content.gsub!(/isReadable: 1/, 'isReadable: 0')
    IO.write(file, content)
  end

  fix_efx_mesh_settings
end

def read_asset_db
  JSON.parse(IO.read("#{unity_dir}/assetdb.json"))
end

# fix the efx mesh readable for emmitting mesh
def fix_efx_mesh_settings
  assetdb = read_asset_db
  readable_files = []
  files = get_asset_files('Prefab/misc/**/*.prefab')
  files.concat(get_asset_files('Prefab/cutscenes/**/*.prefab'))
  files.each do |file|
    # puts file
    prefab_reader = PrefabReader.new(IO.read(file))
    prefab_reader.each_chunk('ParticleSystemRenderer') do |chunk, index|
      renderMode = chunk.scan(/m_RenderMode: (\d+)/).flatten.first
      if renderMode == '4'
        guid = chunk.scan(/m_Mesh: {fileID: \d+, guid: (\w+), type: \d}/).flatten.first
        readable_files |= [assetdb[guid]] if guid
      end
    end
  end

  readable_files.each do |file|
    meta_file = "#{unity_dir}/#{file}.meta"
    next unless File.exist?(meta_file)
    meta = IO.read(meta_file)
    meta.gsub!('isReadable: 0', 'isReadable: 1')
    IO.write(meta_file, meta)
  end
end

def fix_sounds_bundle
  files = FileList["#{unity_dir}/Assets/sounds/efx/**/*.meta"]
  files.each do |file|
    content = IO.read(file)

    name = File.basename(file)
    arr = name.split('.')
    next if arr.size == 2
    name = name.split('.').first
    arr = name.split('_')

    bundle_name = 'sounds/efx.ab'

    if arr.size > 2
      bundle_name = "sounds/#{arr[0..1].join('_')}.ab"
    elsif arr.size > 1
      bundle_name = "sounds/#{arr[0]}.ab"
    end

    content.gsub!(/assetBundleName: .*/, "assetBundleName: #{bundle_name}")
    puts bundle_name
    IO.write(file, content)
  end
end

EXCLUDES = [
  '',
  '*.meta',
  '*.fbx',
  '*.asset',
  '*~',
  '*.mat',
  '*.FBX',
  '.DS_Store'
]

EXCLUDES2 = [
  '',
  '*.fbx',
  '*.asset',
  '*~',
  '*.mat',
  '*.FBX',
  '.DS_Store'
]

GREP = "'^(>|\*)'"


def _sync_ld_temp(src_dir, dest_dir)
  excludes = EXCLUDES2.join(' --exclude ')
  system("mkdir -p #{dest_dir}")
  system(%(rsync -acmi --delete-after --delete-excluded #{excludes} #{src_dir} #{dest_dir}))
end


def cleanup(platform)
  bundle_root = bundle_root(platform)

  manifest_file = "#{bundle_root}/#{platform}.manifest"
  return if !File.exist?(manifest_file)
  
  b = YAML.load(IO.read(manifest_file))
  manifest = b['AssetBundleManifest']['AssetBundleInfos']
  list = manifest.map { |_, v| v['Name'] }
  files = []

  Dir.glob("#{bundle_root}/**/*.{ab,ab.ld,ab.hd}") do |file|
    file =~ /\/AssetBundles\/#{platform}\/(.+)/
    files << Regexp.last_match(1)
  end

  extra = files - list
  extra.each do |file|
    File.delete("#{bundle_root}/#{file}")
  end

  manifest_list = []

  Dir.glob("#{bundle_root}/**/*.ab.{manifest,ld.manifest,hd.manifest}") do |file|
    file =~ /\/AssetBundles\/#{platform}\/(.+)\.manifest/
    manifest_list << Regexp.last_match(1) if Regexp.last_match(1)
  end

  extra = manifest_list - list

  extra.each do |file|
    File.delete("#{bundle_root}/#{file}.manifest")
  end

  if bundle_root then
    file = "#{bundle_root}/all_bundles.json"
    IO.write(file, JSON.pretty_generate(manifest_list))
    merge(jsonFiles: [file],
          folder: "#{bundle_root}/")
  end
end

def good_str(str, file = '')
  unless str.valid_encoding?
    puts "invalid byte found on #{file}, maybe corrupted"
  end
  str
end

def check_meta_files
  files = FileList["#{unity_dir}/Assets/**/*.meta"]
  files.each do |file|
    str = IO.read(file)
    begin
      yml = YAML.load(str)
    rescue => e
      # puts e
      puts "#{file} is invalid yaml"
    end
  end
end

def write_clip_info(bundle_root = nil)
  files = FileList["#{unity_dir}/Assets/Model/animations/**/*.anim"]
  hash = {}
  loop_hash = {}
  # puts files
  files.each do |clip|
    # puts "write_clip_info processing clip #{clip}"
    str = IO.read(clip)
    str = good_str(str, clip)

    name = File.basename(clip, '.anim')
    list = str.scan(/time: (.+)/)
    list = list.map { |x| x.first.to_f }
    max = list.max
    length = max
    puts "error #{name} exist before in #{clip}" if hash[name]
    hash[name] = length
    is_loop = str.scan(/m_LoopTime: 1/).size > 0
    loop_hash[name] = is_loop if is_loop

    fail "clip #{name} is invalid" if length.nil?
    # puts "write_clip_info done processing clip #{clip}"
  end

  IO.write("#{unity_dir}/Assets/StreamingAssets/animClips.json", JSON.pretty_generate(hash))
  IO.write("#{unity_dir}/Assets/StreamingAssets/animLoops.json", JSON.pretty_generate(loop_hash))

  folder = "#{unity_dir}/Assets/StreamingAssets/"

  if bundle_root
    folder = "#{bundle_root}/"
  end

  merge(jsonFiles: [
    "#{unity_dir}/Assets/StreamingAssets/animClips.json",
    "#{unity_dir}/Assets/StreamingAssets/animLoops.json",
    ],
  folder: folder)
end

def check_ui
  guid_mask = 'f5f67c52d1564df4a8936ccd202a3bd8'

  files = FileList["#{unity_dir}/Assets/prefab/ui/**/*.prefab"]
  # files = FileList["#{unity_dir}/Assets/empty.prefab"]
  files.each do |file|
    str = IO.read(file)

    gos = str.scan(/^GameObject:/)
    masks = str.scan(/m_ShowMaskGraphic:/)
    index = file.index('Assets')
    path = file[index..-1]
    bgs = str.scan(/m_Name: bg/)

    if gos.size >= 500
      puts "#{path} 单位节点数(gameObjects)过高 count=#{gos.size}"
      puts "#{path} bg数量过高 count=#{bgs.size}" if bgs.size > 100
    end

    if masks.size > 30
      # puts "#{path} mask数量过高 count=#{masks.size}"
    end

    if bgs.size > 50
      # puts "#{path} bg数量过高 count=#{bgs.size}"
    end
  end
end

def check_particle_system_count
  files = FileList["#{unity_dir}/Assets/prefab/misc/**/*.prefab"]
  # files = FileList["#{unity_dir}/Assets/empty.prefab"]
  #
  #
  config_str = IO.read("#{ENV['ZHS']}/game-config/config.json")
  asset_str = IO.read("#{ENV['ZHS']}/game-config/assets.json")

  lines = []

  files.each do |file|
    str = IO.read(file)

    particle_systems = str.scan(/^ParticleSystem:/)
    index = file.index('Assets')
    path = file[index..-1]
    name = File.basename(path, '.prefab')

    if particle_systems.size >= 20
      # puts "#{path} ParticleSystem 节点数超过20 count=#{particle_systems.size}"
      o = {}
      o['name'] = name
      o['num'] = particle_systems.size
      lines << o
    end

  end

  lines.sort!{|x, y|
    y['num'] <=> x['num']
  }
  lines = lines.map {|x| "#{x['name']}, #{x['num']}"}

  IO.write('particle_count.csv', lines.join("\n"))
  puts JSON.pretty_generate(unused)
end

def get_asset_database
  meta_files = FileList["#{unity_dir}/Assets/**/*.meta"]
  files = {}

  meta_hash = {}
  meta_files.each do |meta_file|
    content = IO.read(meta_file)
    guid = content.scan(/guid: (\w+)/).flatten.first
    file = meta_file.sub('.meta', '')
    index = file.index('Assets')
    file = file[index..-1]
    meta_hash[guid] = file
  end

  meta_hash
end

def get_prefab_depends
  db = JSON.parse(IO.read('assetdb.json'))

  prefab_depends = {}
  prefabs = FileList["#{unity_dir}/Assets/Prefab/**/*.prefab"]
  prefabs |= FileList["#{unity_dir}/Assets/**/*.mat"]
  prefabs |= FileList["#{unity_dir}/Assets/**/*.unity"]
  prefabs |= FileList["#{unity_dir}/Assets/**/*.anim"]
  prefabs.each do |file|
    content = IO.read(file)
    content = good_str(content, file)
    guids = content.scan(/fileID: \d+, guid: (\w+)/).flatten.uniq

    depends = []
    guids.each do |guid|
      depends << db[guid] if db[guid]
    end

    index = file.index('Assets')
    path = file[index..-1]
    prefab_depends[path] = depends
  end

  prefab_depends
end


def build_none_square_textures
  files = FileList[
    "#{unity_dir}/Assets/Models/**/*.tga",
    "#{unity_dir}/Assets/Models/**/*.TGA",
  ]

  files.uniq!

  list = []

  files.each do |file|
    reader = TextureReader.new(file)
    reader.calc_size
    if reader.none_square?
      o = reader.to_size_hash
      list << o
    end
  end

  IO.write("#{unity_dir}/none_square_textures.json", JSON.pretty_generate(list))
end

def build_asset_database
  meta_hash = get_asset_database
  IO.write("#{unity_dir}/assetdb.json", JSON.pretty_generate(meta_hash))
end

def check_efx_particles
  files = FileList["#{unity_dir}/Assets/Prefab/misc/*.prefab"]

  files.each do |file|
    content = IO.read(file)
    max_particles = content.scan(/maxNumParticles: (\d+)/).flatten.map(&:to_i)
    boxColliders = content.scan(/Collider:/).flatten.map
    index = file.index('Assets/')
    path = file[index..-1]

    puts "#{path} has colliders" if boxColliders.size > 0

    max = max_particles.max if max_particles.size > 0
    max ||= 0
    puts "#{path} max_particles = #{max}" if max > 200
  end
end

def check_efx_prefab_depends
  prefab_depends = get_prefab_depends

  prefabs = FileList["#{unity_dir}/Assets/Prefab/misc/**/*.prefab"]
  prefabs |= FileList["#{unity_dir}/Assets/Particles/effects/**/*.mat"]
  prefabs.each do |file|
    index = file.index('Assets')
    path = file[index..-1]

    depends = prefab_depends[path]
    depends.each do |dep|
      if dep['Models/streets'] || dep['Model/characters']
        puts "#{path} depends #{dep}"
      end
    end if depends
  end
end

def write_sprite_info(bundle_root = nil)
  fileList = FileList["#{unity_dir2}/Assets/Images/**/*.tpsheet"]
  hash = {}
  fileList.each do |file|
    name = File.basename(file, '.tpsheet')
    str = IO.read(file)
    index = file.index('Images')
    # puts ">>>file:#{file} str:#{str}"
    path = file[index..-1]
    path['.tpsheet'] = ''
    path = path.downcase
    sprites = str.scan(/^(.+);.+/)
    sprites.each do |f|
      spriteName = f.first.split(';').first
      if hash[spriteName]
        puts "error #{spriteName} exists before in #{hash[spriteName]} cur=#{path}"
      end
      hash[spriteName] = path
    end
  end
  IO.write(BuildArt.streaming_dir + '/' + 'sprites.json', JSON.pretty_generate(hash))
  folder = "#{unity_dir2}/Assets/StreamingAssets/"
  if bundle_root
    folder = "#{bundle_root}/"
    system("cp #{unity_dir2}/Assets/StreamingAssets/sprites.json #{bundle_root}/")
  end
  
  merge(jsonFiles: [BuildArt.streaming_dir + '/' + 'sprites.json', BuildArt.streaming_dir + '/' + 'map.json'],
        folder: folder)
end

def write_sounds_info
  fileList = FileList["#{unity_dir}/Assets/sounds/**/*.mp3"]
  hash = {}
  fileList.each do |file|
    name = File.basename(file, '.mp3')
    dir = File.dirname(file)
    index = dir.index('sounds')
    dir = dir[index..-1].downcase
    path = dir + '/' + name
    hash[name] = path
  end

  IO.write(BuildArt.streaming_dir + '/' + 'sounds.json', JSON.pretty_generate(hash))
  merge(jsonFiles: [BuildArt.streaming_dir + '/' + 'sounds.json'],
        folder: "#{unity_dir}/Assets/StreamingAssets/")
end

def write_bundle_info(platform, copy_to_bundle_root = false)
  bundle_root = bundle_root(platform)

  art_dir = "#{bundle_root}/prefab/"
  files = Dir.glob(art_dir + '**/*.manifest')
  
  prefabs = {}
  sounds = {}
  images = {}
  textures = {}
  scenes = {}
  water_cubemaps = {}
  scene_assets = {}
  materials = {}
  puts ">>>>enter111:#{files}"
  files.each do |file|
    puts ">>>>enter222:#{file}"
    o = YAML.load(IO.read(file))
    o['Assets'].each do |uri|
      uri = uri.downcase
      next unless uri['.prefab']
      dir = File.dirname(file)
      index = dir.index('prefab')
      dir = dir[index..-1]
      name = File.basename(file, '.ab.manifest')
      prefabs[uri] = dir + '/' + name
    end
  end

  art_dir = "#{bundle_root}/sounds/"
  files = Dir.glob(art_dir + '**/*.manifest')

  files.each do |file|
    o = YAML.load(IO.read(file))
    o['Assets'].each do |prefab|
      uri = prefab.downcase
      dir = File.dirname(file)
      index = dir.index('sounds')
      dir = dir[index..-1]
      name = File.basename(file, '.ab.manifest')
      sounds[uri] = dir + '/' + name
    end
  end

  art_dir = "#{bundle_root}/images/"
  files = Dir.glob(art_dir + '**/*.manifest')

  files.each do |file|
    o = YAML.load(IO.read(file))
    o['Assets'].each do |prefab|
      uri = prefab.downcase
      dir = File.dirname(file)
      index = dir.index('images')
      dir = dir[index..-1]
      name = File.basename(file, '.ab.manifest')
      images[uri] = dir + '/' + name
    end
  end

  art_dir = "#{bundle_root}/images_mask/"
  files = Dir.glob(art_dir + '**/*.manifest')

  files.each do |file|
    o = YAML.load(IO.read(file))
    o['Assets'].each do |prefab|
      uri = prefab.downcase
      next unless uri['.mat']
      dir = File.dirname(file)
      index = dir.index('images')
      dir = dir[index..-1]
      name = File.basename(file, '.ab.manifest')
      materials[uri] = dir + '/' + name
    end
  end

  art_dir = "#{bundle_root}/scenes/"
  files = Dir.glob(art_dir + '**/*.manifest')

  files.each do |file|
    puts ">>>>enter333:#{file}"
    o = YAML.load(IO.read(file))
    o['Assets'].each do |prefab|
      uri = prefab.downcase
      dir = File.dirname(file)
      index = dir.index('scenes')
      dir = dir[index..-1]
      name = File.basename(file, '.ab.manifest')
      scene_assets[uri] = dir + '/' + name
      next unless uri['.unity']
      scenes[uri] = dir + '/' + name
    end
  end


  art_dir = "#{bundle_root}/textures/scenes/"
  files = files.concat(FileList[art_dir + '**/*.manifest'])

  art_dir = "#{bundle_root}/materials/scenes/"
  files = files.concat(FileList.new(art_dir + '**/*.manifest'))

  files.each do |file|
    o = YAML.load(IO.read(file))
    o['Assets'].each do |prefab|
      uri = prefab.downcase

      dir = File.dirname(file)
      index = dir.index('textures/scenes') || dir.index('materials/scenes') || dir.index('scenes')
      dir = dir[index..-1]
      name = File.basename(file, File.extname(file))
      scene_assets[uri] = dir + '/' + name
    end
  end

  data = {
    'prefabs' => ::Hash[prefabs.sort_by{|k, v| k}],
    'sounds' => ::Hash[sounds.sort_by{|k, v| k}],
    'images' => ::Hash[images.sort_by{|k,v| k}],
    'scenes' => ::Hash[scenes.sort_by{|k,v| k}],
    'materials' => materials
  }

  file = "#{unity_dir}/Assets/StreamingAssets/bundles_#{platform}.json"
  puts ">>>>enter444:#{file}"
  IO.write(file, JSON.pretty_generate(data))
  merge(jsonFiles: [file],
        folder: "#{unity_dir}/Assets/StreamingAssets/")

  if copy_to_bundle_root
    write_sprite_info(bundle_root)
    write_ui_info(bundle_root)

    system("cp #{file} #{bundle_root}/")

    merge(jsonFiles: [file],
          folder: "#{bundle_root}/")
  end

  # file = "#{unity_dir}/Assets/StreamingAssets/depends_#{platform}.json"
  # IO.write(file, JSON.pretty_generate(depends))
  # merge(jsonFiles: [file],
  #       folder: "#{unity_dir}/Assets/StreamingAssets/")
end

def merge_exec
  File.join(unity_dir2, 'merge_jsons.rb')
end

def merge(options)
  jsonFiles = options[:jsonFiles]
  puts "<<<<<<jsonFiles:#{jsonFiles}"
  folder = options[:folder]
  includes = options[:includes]
  puts "<<<<<<<merge_exec:#{merge_exec}"
  if includes
    ruby "#{merge_exec} merge #{jsonFiles.join(' ')} -f #{folder} -i #{includes.join(' ')}"
  else
    ruby "#{merge_exec} merge #{jsonFiles.join(' ')} -f #{folder}"
  end
end

def has_duplicate_scene_textures
  system("rake asset:texture_duplicate > #{unity_dir}/duplicates.txt")
  duplicates = IO.read("#{unity_dir}/duplicates.txt")
  if duplicates.lines.size > 0
    fail "Build bundle failed! \nhas duplicate textures #{duplicates}; \n Bundle collisions might happen.\n".colorize(:red)
    return true
  end
  false
end

def pot2?(n)
  n.to_s(2).count('1') == 1
end

def fix_npot_textures
  list = FileList["#{unity_dir}/Assets/Resources/**/*.png"]

  list.each do |file|
    image = MiniMagick::Image.open(file)
    next if pot2?(image.width) && pot2?(image.height)

    puts "none-pot texture #{file}"
    # meta_file = file + '.meta'
    # content = IO.read(meta_file)
    # content.gsub!(/nPOTScale: 0/, 'nPOTScale: 1')
    # IO.write(meta_file, content)
  end
end

def has_invalid_assets
  false  
end

namespace :bundle do

  task :fix_prefab_settings do
    fix_prefab_settings
  end

  task :fix_efx_bundle do
    fix_efx_bundle
  end

  task :fix_sounds_bundle do
    fix_sounds_bundle
  end

  task :fix_npot_textures do
    fix_npot_textures
  end

  task :assetdb do
    build_asset_database
  end

  task :animator_depends do
    build_animator_depends
  end

  desc 'check particle system count'
  task :check_ps do
    check_particle_system_count
  end

  desc 'check efx depends assets'
  task :check_efx_depends do
    check_efx_prefab_depends
  end

  desc 'Check ui'
  task :check_ui do
    check_ui
  end

  desc 'Build sprites info'
  task :sprites do
    write_sprite_info
  end

  desc 'Build sounds info'
  task :sounds do
    write_sounds_info
  end

  desc 'write anim clips info'
  task :clips do
    write_clip_info
  end

  desc 'check meta file validity'
  task :check_meta_files do
    check_meta_files
  end

  task :merge do
    fileList = FileList['Assets/StreamingAssets/*.json']
    fileList.exclude(/config/)

    merge(jsonFiles: fileList,
          folder: 'Assets/StreamingAssets/')
  end

  desc 'reimport ios'
  task :import_ios do
    success = reimport('ios')
    abort unless success
  end

  desc 'reimport streets models'
  task :import_street_models do
    success = reimport_modelstreets('ios')
    abort unless success
  end

  desc 'reimport android'
  task :import_android do
    success = reimport('android')
    abort unless success
  end

  desc 'reimport osx'
  task :import_osx do
    success = reimport('osx')
    abort unless success
  end

  desc 'Build osx Asset bundles'
  task :osx do
    # abort if has_invalid_assets
    # fix_prefab_settings
    success = build_bundle("#{art_dir}/AssetBundles/osx/", 'osx')
    cleanup('osx')
    write_bundle_info('osx')
    write_sprite_info
    write_clip_info
    write_ui_info
    write_particle_info
    abort unless success
  end

  desc 'Build ios Asset bundles'
  task :ios do
    # abort if has_invalid_assets
    # build_asset_database
    # fix_prefab_settings
    success = build_bundle("#{art_dir}/AssetBundles/ios/", 'ios')
    cleanup('ios')
    write_bundle_info('ios', true)
    write_particle_info
    # write_sounds_info
    write_clip_info
    abort unless success
  end

  task :ios_simple do
    # abort if has_invalid_assets
    # build_asset_database
    # fix_prefab_settings
    success = build_bundle("#{art_dir}/AssetBundles/ios/", 'ios')
    cleanup('ios')
    write_bundle_info('ios', true)
    write_particle_info
    # write_sounds_info
    write_clip_info
    abort unless success
  end

  desc 'Build android Asset bundles'
  task :android do
    # abort if has_invalid_assets
    # build_asset_database
    # fix_prefab_settings
    success = build_bundle("#{art_dir}/AssetBundles/android/", 'android')
    puts ">>>>enter000:#{success}"
    cleanup('android')
    write_bundle_info('android', true)
    write_particle_info
    # write_sounds_info
    abort unless success
  end

  desc 'write the bundles info'
  task :info do
    write_bundle_info('ios')
    write_bundle_info('android', true)
    # write_bundle_info('osx')
  end

  desc 'Bootstrap'
  task :bootstrap do
    success = bootstrap
    write_clip_info
    abort unless success
  end

  desc 'create mainscene controllers'
  task :ms_controllers do
    success = ms_controllers
    abort unless success
  end

  task :fix_efx_mesh do
    fix_efx_mesh_settings
  end

  task :check_efx_particles do
    check_efx_particles
  end

  task :fix_image_metas do
    fix_image_metas
  end

  task :scan_ui do
    scan_ui
  end

  task :bootstrap_combat_particles do
    bootstrap_combat_particles
  end

  task :bootstrap_sprite_assets do
    bootstrap_sprite_assets
    write_sprite_info
  end

  task :fix_controllers do
    fix_controllers
  end

  task :write_particle_info do
    write_particle_info
  end


  task :fix_anim_settings do
    fix_anim_settings
  end


  task :find_unused_animations do
    find_unused_animations
  end


  desc 'Build all bundles'
  task all: [:ios, :android]

  task ios_all: [:ios]

  task android_all: [:android]

  task osx_all: [:osx]

  desc 'cleanup unused asset bundles'
  task :cleanup do
    cleanup('osx')
    cleanup('ios')
    cleanup('android')
  end
end
