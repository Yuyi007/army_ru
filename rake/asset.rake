require 'tradsim'
namespace :asset do
  def art_dir
    Boot::Tools.config.art_root
  end

  def identify(files, prefix = 'scene')
    signatures = {}
    files.each do |file|
      # image = MiniMagick::Image.open(file)
      # res = image.signature
      # res = Digest::MD5.hexdigest(IO.read(file))
      # puts res
      res = `identify -verbose "#{file}" | grep signature`
      signatures[res] ||= []
      signatures[res] << file
    end
    arr = []

    signatures.each do |_sign, files|
      if files.size > 1
        arr << "同样的图片"
        arr.concat(files)
        arr << ""
      end
    end

    IO.write("same_#{prefix}_textures.txt", arr.join("\n"))

    return signatures
  end

  def id_ui_size(files)
    files.each do |file|
      res = `identify "#{file}"`
      size = res.split(' ')[2]
      width, height = size.split('x').map {|x| x.to_i}
      if width > 1024 || height > 1024
        puts "image file size too large #{file} size = #{size}"
      end
    end
  end

  def texture_count(path, size)
    count = `cat #{path} | xargs -I {} identify {} | grep #{size} | wc -l`
    count = count.to_i
    c = `find #{path}  -name *.png | xargs -I {} identify {} | grep #{size} | wc -l`
    count += c.to_i
    count
  end

  def texture_collect(path, _size)
    files = `find #{path}  -name *.tga`
    list = files.split("\n")
    files = `find #{path} -name *.png`
    list = list.concat(files.split("\n"))
    pp list

    # count = count.to_i
    # c = `find #{path} . -name *.png | xargs -I {} identify {} | grep #{size} | wc -l`
    # count += c.to_i
    # count
  end

  def texture_format(_scene, format)
    count = `find #{path}  -name *.tga | xargs -I {} identify {} | grep #{format} | wc -l`
    count = `find #{path}  -name *.png | xargs -I {} identify {} | grep #{format} | wc -l`
    count
  end

  T_MULTI = {
    '256x256' => 0.25,
    '512x512' => 1,
    '128x128' => 0.0625,
    '1024x1024' => 4,
    '2048x2048' => 16,
    '64x64' => 0.0625 / 4,
    '32x32' => 0.0625 / 16,
  }

  def translate_count(textures)
    t = 0
    textures.each do |size, total|
      t += total * T_MULTI[size]
    end

    return t
  end

  def count(scene)
    path = "scene_textures/#{scene}_textures.txt"
    textures = {
      '256x256' => 0,
      '512x512' => 0,
      '128x128' => 0,
      '1024x1024' => 0,
      '2048x2048' => 0,
      '64x64' => 0,
      '32x32' => 0
    }

    textures.each do |size, _total|
      textures[size] = texture_count(path, size)
    end

    total = translate_count(textures)

    puts "scene #{scene}"
    puts JSON.pretty_generate(textures)
    puts "#{scene} translated count of 512x512=#{total}"
  end

  def format(path)
    textures = {
      '8-bit' => 0,
      '16-bit' => 0,
      '24-bit' => 0,
      '32-bit' => 0
    }

    textures.each do |format, _total|
      textures[format] = texture_count(path, format)
    end

    puts "path #{path}"
    puts JSON.pretty_generate(textures)
  end

  def identify_size(path)
    textures = {
      '256x256' => [],
      '512x512' => [],
      '128x128' => [],
      '1024x1024' => [],
      '64x64' => [],
      '32x32' => []
    }

    textures.each do |size, _total|
      textures[size] = texture_collect(path, size)
    end
  end

  desc 'identify duplciate effect images'
  task :identify_effects do
    files = Dir.glob('./Assets/Particles/effects/**/*.png')
    files.concat Dir.glob('./Assets/Particles/effects/**/*.tga')
    files.uniq!
    identify(files)
  end

  desc 'identify UI'
  task :identify_ui do
    files = Dir.glob('../kof_art/png/symbol/*.png')
    identify(files)
  end

  def size(file)
    # res = FastImage.size(file) #{}`identify "#{file}"`
    res = `identify "#{file}"`
    # puts ">>> file:#{file} res:#{res}"
    # [res[0], res[1]]
    size = res.split(' ')[2]
    width, height = size.split('x').map(&:to_i)
    [width, height]
  end

  desc 'check character textures with alpha channel'
  task :check_alpha_textures do
    files  = FileList[
      "#{unity_dir}/Assets/Model/characters/**/*.tga",
      "#{unity_dir}/Assets/Model/characters/**/*.TGA",
      "#{unity_dir}/Assets/Model/clothes/**/*.TGA",
      "#{unity_dir}/Assets/Model/clothes/**/*.tga",
    ]

    files.uniq!
    list = []
    files.each do |path|
      res = `identify -format '%[channels]' #{path}`
      if res == 'rgba' || res == 'srgba'
        index = path.index('Assets')
        file = path[index..-1]
        list << file
      end
    end

    IO.write("alpha_textures.csv", list.join("\n"))
  end



  task :check_scene_square_textures do
    list = []

    files  = FileList[
      "#{unity_dir}/Assets/Models/streets/**/*.tga",
      "#{unity_dir}/Assets/Models/streets/**/*.TGA",
    ]
    files.uniq!
    files.each do |file|
      width, height = size(file)
      index = file.index('Assets')
      path = file[index..-1]
      if width != height then
        o = []
        o << path
        o << width
        o << height
        list << o.join(',')
      end
    end

    IO.write("none_square_textures.csv", list.join("\n"))
  end


  desc 'identify duplicate street model images'
  task :identify_streets do
    files = Dir.glob('./Assets/Models/streets/**/*.tga')
    identify(files)
  end



  desc 'find problematic assets'
  task :problem do
    system('rake asset:identify_effects asset:identify_streets')
  end

  desc 'count textures'
  task :textures do
    count('cit001')
    count('cit002')
    count('cit003')
    count('cit004')
    count('cit005')
  end

  task :texture_space do
    files = Dir.glob('./Assets/Models/streets/**/*.tga')
    files.concat Dir.glob('./Assets/Models/streets/**/*.TGA')
    files.uniq!
    files = files.select {|x| x[' ']}
    puts files
  end

  task :efx_texture_dup do
    files = Dir.glob("#{unity_dir}/Assets/Particles/effects/fx_Textures/*.tga")
    files.uniq!

    identify(files, 'efx')
  end

  def get_texture_hash(files)
    texture_hash = {}
    sprite_hash = {}
    files.each do |file|


      content = YAML.load(IO.read(file))
      index = file.index('Assets')
      path = file[index..-1]
      path['.meta'] = ''

      file_sprite_hash = content['TextureImporter']['fileIDToRecycleName']
      guid = content['guid']

      sprite_hash[guid] ||= {}
      sprite_hash[guid].merge!(file_sprite_hash)
      texture_hash[content['guid']] = path
    end

    return texture_hash, sprite_hash
  end

  def check_ui_anim(files, sprite_hash, sprite_used)
    anims = files
    anims.each do |file|
      index = file.index('Assets')
      path = file[index..-1]
      str = IO.read(file)

      o = str.scan(/ {fileID: (\d+), guid: (\w+)/)

      o.each do |(fileid, guid)|
        if sprite_hash[guid]
          sprite = sprite_hash[guid][fileid.to_i]
          sprite_used[sprite] ||= []
          sprite_used[sprite] |= [path]
        end
      end
    end
  end

  task :check_efx do
    files =  FileList["#{unity_dir}/Assets/Prefab/misc/**/*.prefab"]
    list = []
    files.each do |file|
      str = IO.read(file)
      lines = IO.readlines(file)
      header = lines[0..1]
      subs = str.scan(/--- .+/)
      # puts subs
      chunks = str.split(/--- .+/)
      unused_id = {}
      chunks.each_with_index do |o, index|
        list = o.scan(/m_Script: {fileID: 0}/)
        if list.size > 0
          s = subs[index-1]
          puts "s=#{s}"
          s =~ (/--- !u!\d+ &(\d+)/)
          id = $1
          puts id
          unused_id[id] = true
          chunks[index] = ''
        end
      end


      list = []
      list << chunks[0]
      chunks.each_with_index do |o, index|
        if index > 0 && o != ''
          list << subs[index - 1]
          list << o
        end
      end

      str = list.join("")
      lst = str.lines
      lst.delete_if do |x|
        unused_id.any? {|id, _|
          x =~ /- \d+: {fileID: #{id}}/
        }
      end

      str = lst.join("")

      # puts unused_id unless unused_id.empty?
      IO.write(file, str)
    end

    # puts list
  end

  task :check_face do
    npc_face_mats = FileList["#{unity_dir}/Assets/Model/characters/**/*_face.mat"]
    npc_face_mats |= FileList["#{unity_dir}/Assets/Model/clothes/**/*_face_*.mat"]

    npc_face_mats.each do |x|
      index = x.index('Assets')
      x = x[index..-1]
      puts x
    end

    npc_face_mats.each do |file|
      str = IO.read(file)
      str.gsub!("m_Scale: {x: 1, y: 1}", "m_Scale: {x: 2, y: 2}")
      # IO.write(file, str)
    end

    # puts npc_face_mats
  end

  task :check_scripts do
    prefabs = FileList["#{unity_dir}/Assets/Prefab/ui/**/*.prefab"].map {|x| x.downcase}
    prefabs.delete_if {|x| x[/comic|tycoon|making|node|animation/]}
    prefab_used = {}

    files = FileList["#{ENV['KFS']}/client/scripts/**/*.lua"]
    list = []

    requires = []
    files.map do |file|
      index = file.index('scripts')
      path = file[index..-1]
      path['scripts/'] = ''
      path['.lua'] = ''
      if path['game']  && !path['proto'] && !path['test']
        list << path.downcase
      end

      str = IO.read(file)
      requires |= str.scan(/require ['"](.+)['"]/).flatten.map {|x| x.downcase}
      prefab_list = str.scan(/['"](prefab\/.+)['"]/).flatten
      prefab_list.each do |prefab|
        path = "#{unity_dir}/Assets/#{prefab}.prefab".downcase
        prefab_used[path] = true
      end
    end

    # puts prefab_used.keys

    unused_prefabs = prefabs - prefab_used.keys
    puts unused_prefabs


    requires.flatten!

    # puts list
    # puts requires

    # puts list
    # puts requires


    unused = (list - requires)
    unused.each do |file|
      file = "#{ENV['KFS']}/client/scripts/#{file}.lua"
      # puts file
      File.delete(file)
    end
  end

  task :check_face do
    # files = FileList["#{unity_dir}/Assets/"]
  end

  task :ui_textures do
    config = IO.read("#{ENV['KFS']}/game-config/config.json")
    icon_list = []
    icons = config.scan(/\".*icon.*\": "(\w+)"/).flatten

    icon_list |= icons
    icons = config.scan(/"resources": "(\w+)"/).flatten
    icon_list |= icons

    icons = config.scan(/"res_id": "(\w+)"/).flatten
    icon_list |= icons

    icons = config.scan(/"assets": "(\w+)"/).flatten
    icon_list |= icons

    icons = config.scan(/".*pic.*": "(\w+)"/).flatten
    icon_list |= icons

    icon_list = ::Hash[icon_list.map {|x| [x, true]}]
    icon_list.clone.each do |k, v|
      icon_list["#{k}_cb"] = true
      icon_list["#{k}_ft"] = true
    end
    # puts icon_list

    # puts icon_list
    # next

    sprites = JSON.parse(IO.read("#{unity_dir}/Assets/StreamingAssets/sprites.json"))
    sprites.delete_if do |k, v|
     k['icn'] || v['uianim'] ||
     v['mobileapp'] || v['classicon'] || v['sns'] || v['/map'] || v['/news'] || k['font'] || k['equip'] || k['gem'] || k['weather'] || v['zhuanjing']
    end

    sprite_used = {}

    meta_files = FileList["#{unity_dir}/Assets/images/**/*.png.meta"]
    texture_hash, sprite_hash = get_texture_hash(meta_files)
    prefab_textures = {}
    texture_hash.each do |guid, texture|
      prefab_textures[texture] = []
    end

    # prefab_files = FileList["#{unity_dir}/Assets/Prefab/ui/**/*.prefab"]
    prefab_files = FileList["#{unity_dir}/Assets/Prefab/**/*.prefab"]
    prefab_files.each do |file|
      index = file.index('Assets')
      path = file[index..-1]
      str = IO.read(file)

      o = str.scan(/m_Sprite: {fileID: (\d+), guid: (\w+), /)

      o.each do |(fileid, guid)|
        if sprite_hash[guid]
          sprite = sprite_hash[guid][fileid.to_i]
          sprite_used[sprite] ||= []
          sprite_used[sprite] |= [path]
        end

        if texture_hash[guid]
          prefab_textures[texture_hash[guid]] ||= []
          prefab_textures[texture_hash[guid]] |= [path]
        end
      end
    end

    check_ui_anim(FileList["#{unity_dir}/Assets/**/*.anim"], sprite_hash, sprite_used)

    sprite_used.each do |sprite, _|
      sprites.delete(sprite)
    end

    icon_list.each do |sprite, _|
      sprites.delete(sprite)
    end

    IO.write('unused_sprites.json', JSON.pretty_generate(sprites))
    IO.write('ui_textures.json', JSON.pretty_generate(prefab_textures))
    IO.write('sprite_textures.json', JSON.pretty_generate(sprite_used))
  end

  task :efx_texture do
    texture_files = Dir.glob("#{unity_dir}/Assets/Particles/effects/fx_Textures/*.tga.meta")


    texture_hash = {}
    texture_files.each do |file|
      content = YAML.load(IO.read(file))
      index = file.index('Assets')
      path = file[index..-1]
      path['.meta'] = ''
      texture_hash[content['guid']] = path
    end

    mat_hash = {}

    texture_materials = {}

    mat_files = Dir.glob("#{unity_dir}/Assets/Particles/effects/fx_Materials/*.mat")
    mat_files.each do |file|
      index = file.index('Assets')
      path = file[index..-1]
      str = IO.read(file)
      puts file
      o = str.scan(/m_Texture: {fileID: \d+, guid: (\w+), /)

      # o = list.find {|x| x['first']['name'] == '_MainTex'}
      if o
        guid = o.flatten.first
        if texture_hash[guid]
          texture_materials[texture_hash[guid]] ||= []
          texture_materials[texture_hash[guid]] << path
        end
      end
    end

    prefab_materials = {}


    mat_meta_files = Dir.glob("#{unity_dir}/Assets/Particles/effects/fx_Materials/*.mat.meta")
    mat_meta_files.each do |file|
      content = YAML.load(IO.read(file))
      index = file.index('Assets')
      path = file[index..-1]
      path['.meta'] = ''
      mat_hash[content['guid']] = path
    end

    prefab_files = Dir.glob("#{unity_dir}/Assets/Prefab/misc/*.prefab")
    prefab_files.each do |file|
      index = file.index('Assets')
      path = file[index..-1]
      str = IO.read(file)
      puts file
      o = str.scan(/- {fileID: \d+, guid: (\w+), /).flatten
      o.each do |guid|
        # puts guid
        if mat_hash[guid]
          prefab_materials[mat_hash[guid]] ||= []
          prefab_materials[mat_hash[guid]] << path
        end
      end

    end

    # puts mat_hash
    IO.write('mat_textures.json', JSON.pretty_generate(texture_materials))
    IO.write('mat_prefabs.json', JSON.pretty_generate(prefab_materials))
  end

  task :texture_duplicate do
    files = Dir.glob("#{unity_dir}/Assets/Models/streets/**/*.tga")
    files.concat Dir.glob("#{unity_dir}/Assets/Models/streets/**/*.TGA")
    files.uniq!

    names = {}
    files.each do |file|
      name = File.basename(file)
      names[name] ||= []
      names[name] << file
    end

    names.each do |k, v|
      if v.size > 1
        puts ""
        puts "duplicate #{k} \n #{v.join("\n")}"
      end
    end


  end

  task :textures_collect do
    identify_size('./Assets/particles/effects')
  end

  task :id_ui_size do
    files = Dir.glob("#{art_dir}/png/**/*.png")
    id_ui_size(files)
  end

  desc 'split chinese chars'
  task :split_chars do
    string = IO.read('./Assets/Fonts/Character/chs.txt')
    string = Tradsim.to_sim(string)
    chars = string.chars.uniq
    count = chars.length
    list_count = (count / 1000).floor + 1
    lists = []

    list_count.times do |i|
      lists[i] = []
    end

    chars.each_with_index do |char, idx|
      i = (idx / 1000).floor
      lists[i] << char
    end

    lists.each_with_index do |list, index|
      IO.write("./Assets/Fonts/Character/chs_#{index}.txt", list.join("\n"))
    end
  end

  desc 'analyse character animation usage'
  task :anim_usage do
    config_root = Boot::Tools.config.server_project_root
    project_root = Boot::Tools.config.project_root

    animators = JSON.parse(IO.read("#{config_root}/game-config/animators2.json"))
    anims = []
    all_states = []
    puts "collecting clips (#{animators.length} controllers)..."
    animators.each do |name, states|
      puts "#{name}: #{states.length} states"
      states.each do |state, info|
        anims << {
          'state' => state,
          'clip' => info['clip'],
          'use_count' => 0, # config usage
          'cs_count' => 0, # cutscene usage
        }
        all_states << state
      end
    end
    # all_states = all_states.uniq
    # puts "anims=#{anims.length} all_states=#{all_states.length}"

    puts "preparing cutscene data..."
    all_prefab_lines = []
    Dir.glob("#{project_root}/Assets/Prefab/cutscenes/*.prefab") do |file|
      prefab_lines = IO.read(file).split("\n").reject do |line|
        (line !~ /\s+(Name:|AnimationStateName:)/)
      end
      all_prefab_lines.concat(prefab_lines)
    end
    IO.write("/tmp/all_prefab_lines", all_prefab_lines.join("\n"))
    puts "all_prefab_lines=#{all_prefab_lines.length}"

    puts "preparing config data..."
    config = JSON.parse(IO.read("#{config_root}/game-config-processed/config.json"))
    [ 'items', 'foods', 'bag', 'props', 'formula', 'weather', 'sensitiveWords',
      'jobs', 'job_wages', 'job_events', 'attributes', 'mobile', 'muscle', 'names',
      'emoticons', 'strings', 'explores', 'gems', 'suits', 'equips', 'equips_upgrade',
      'four_therion', 'phonebook', 'skill_anims', 'friendships_ext', 'drops',
      'sns', 'graphdata', 'groups', 'campaigns', 'missions', 'city', 'clips',
      'map_npc', 'npctriggers', 'animators2' ].each do |item|
      config[item] = nil
    end
    config_lines = JSON.pretty_generate(config).split("\n").reject do |line|
      line.length < 5 or line.length > 60 or ((line =~ /\{|\}|\[|\]|\p{Han}|\"(tid|type|scale|drop_id|x|y|z|kind|level|desc|exp|weight|chance|num|category)\"/) != nil)
    end
    IO.write("/tmp/config_lines", config_lines.join("\n"))
    puts "config_lines=#{config_lines.length}"

    print "analysing clips usage (total is #{anims.length})..."
    anims.each do |info|
      state = info['state']
      all_prefab_lines.each do |line|
        if line.include? state
          info['cs_count'] = info['cs_count'] + 1
        end
      end
      config_lines.each do |line|
        if line.include? state
          info['use_count'] = info['use_count'] + 1
        end
      end
      print '.'
    end
    print "\n"

    puts "clips usage collected!"
    anims.sort! do |i1, i2|
      (i1['use_count'] + i1['cs_count'])
    end
    anims.each do |info|
      clip = info['clip']
      state = info['state']
      use_count = info['use_count']
      cs_count = info['cs_count']
      puts "#{clip} (#{state}): design=#{use_count} cutscene=#{cs_count}"
    end
  end

end
