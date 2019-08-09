require_relative 'animator_editor'

class AnimatorsStripper
  attr_accessor :animators_keep
  attr_accessor :controller_src_folder
  attr_accessor :controller_dst_folder
  attr_accessor :prefab_src_folder
  attr_accessor :prefab_dst_folder
  attr_accessor :asset_db_path
  attr_accessor :old_controller_prefix
  attr_accessor :new_controller_prefix
  attr_accessor :old_prefab_suffix
  attr_accessor :new_prefab_suffix
  attr_accessor :store_processed
  attr_accessor :store_processed_config
  attr_accessor :config_path
  attr_accessor :skip_strip_prefab

  def initialize(animators_keep_path)
    self.config_path = animators_keep_path
    self.animators_keep = JSON.parse(IO.read(animators_keep_path))
    self.old_controller_prefix = ''
    self.new_controller_prefix = ''
    self.old_prefab_suffix = ''
    self.new_prefab_suffix = ''
    self.skip_strip_prefab = false
  end

  def start(&blk)
    strip_controllers
    yield if block_given?

    strip_prefabs unless self.skip_strip_prefab

    fix_bundles

    if store_processed && store_processed_config
      system("cp #{config_path} #{store_processed_config}")
      merge(jsonFiles: [store_processed_config],
            folder: "#{unity_dir}/Assets/StreamingAssets/")
    end
  end

  def merge_exec
    File.join(unity_dir, 'merge_jsons.rb')
  end

  def merge(options)
    jsonFiles = options[:jsonFiles]
    folder = options[:folder]
    includes = options[:includes]

    if includes
      system "ruby #{merge_exec} merge #{jsonFiles.join(' ')} -f #{folder} -i #{includes.join(' ')}"
    else
      system "ruby #{merge_exec} merge #{jsonFiles.join(' ')} -f #{folder}"
    end
  end

  def strip_controllers
    system("mkdir -p #{controller_dst_folder}")
    hash = {}
    count = 0

    animators_keep.each do |controller_name, keep_anims|
      count = count + 1
      puts "count=#{count}"

      old_name = "#{old_controller_prefix}#{controller_name}"
      new_name = "#{new_controller_prefix}#{controller_name}"
      src_ctrl_path = "#{controller_src_folder}/#{old_name}.controller"
      dst_ctrl_path = "#{controller_dst_folder}/#{new_name}.controller"
      next unless File.exist?(src_ctrl_path)

      puts "processing keep #{keep_anims.size} states #{src_ctrl_path}\t\t--->\t\t#{dst_ctrl_path}"

      content = IO.read(src_ctrl_path)
      reader = AnimatorEditor.new(content)
      reader.keep_states_by_names(keep_anims.keys)
      reader.content.gsub!(old_name, new_name)
      IO.write(dst_ctrl_path, reader.content)
    end
  end

  def strip_prefabs
    character_prefabs = FileList["#{prefab_src_folder}/*.prefab"]

    system("mkdir -p #{prefab_dst_folder}")

    asset_db = JSON.parse(IO.read(asset_db_path))
    reverse_db = {}

    asset_db.each do |guid, v|
      reverse_db[v] = guid
    end

    character_prefabs.each do |file|
      index = file.index('Assets')
      path = file[index..-1]
      char_name = File.basename(path, '.prefab')
      origin_name = char_name

      if old_prefab_suffix.length > 0
        i = char_name.index(old_prefab_suffix)
        char_name = char_name[0..i - 1]
      end

      controller_name = "#{char_name}_controller"

      next if animators_keep && !animators_keep[controller_name]

      old_controller_path = get_relative_path("#{controller_src_folder}/#{old_controller_prefix}#{char_name}_controller.controller")
      new_controller_path = get_relative_path("#{controller_dst_folder}/#{new_controller_prefix}#{char_name}_controller.controller")

      old_prefab_path = "#{prefab_src_folder}/#{char_name}#{old_prefab_suffix}.prefab"
      new_prefab_path = "#{prefab_dst_folder}/#{char_name}#{new_prefab_suffix}.prefab"

      content = IO.read(old_prefab_path)

      old_guid = reverse_db[old_controller_path]
      new_guid = reverse_db[new_controller_path]

      puts "substitute #{old_guid} -> #{new_guid}"
      puts "for #{old_prefab_path} -> #{new_prefab_path}"
      puts '-' * 20

      content.gsub!(old_guid, new_guid) if old_guid && new_guid

      content.gsub!(origin_name, "#{char_name}#{new_prefab_suffix}")
      IO.write(new_prefab_path, content)
    end
  end

  def get_asset_files(pattern)
    list = FileList["#{pattern}"]
    # puts "pattern=#{pattern} list=#{list}"
    list
  end

  def get_relative_path(path)
    index = path.index('Assets')
    path[index..-1]
  end

  def fix_bundles
    unless controller_dst_folder.empty?

      new_controller_metas = get_asset_files("#{controller_dst_folder}/*.controller.meta")

      new_controller_metas.each do |file|
        # puts file
        content = IO.read(file)
        name = File.basename(file, '.meta')
        name = File.basename(name, '.controller')
        name.gsub!(/^#{new_controller_prefix}/, '')
        bone = name.split('_').first
        content.gsub!(/assetBundleName: .+/, "assetBundleName: prefab/characters/animation_#{bone}_controllers.ab")
        content.gsub!(/licenseType: Free/, "licenseType: Pro")
        IO.write(file, content)
      end
    end

    unless prefab_dst_folder.empty?
      new_characters_metas = get_asset_files("#{prefab_dst_folder}/*.prefab.meta")
      new_characters_metas.each do |file|
        # puts file
        content = IO.read(file)
        name = File.basename(file, '.meta')
        name = File.basename(name, '.prefab')
        arr = name.split('_')
        bone = arr[0]
        role = arr[1]
        content.gsub!(/assetBundleName: .+/, "assetBundleName: prefab/characters/#{bone}/#{role}.ab")
        content.gsub!(/licenseType: Free/, "licenseType: Pro")
        IO.write(file, content)
      end
    end
  end
end
