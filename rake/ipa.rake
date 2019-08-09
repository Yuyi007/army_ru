require 'yaml'
require 'pathname'

namespace :ipa do
  IPA_CONFIG = YAML.load(IO.read('ipa.yml'))

  ORG_PROJ_DIR = "#{ENV['RU']}/proj.ios"
  ORG_PROJ_FILE_PATH = Pathname.new("#{ORG_PROJ_DIR}/Unity-iPhone.xcodeproj")
  ORG_PROJ_PLIST_PATH = Pathname.new("#{ORG_PROJ_DIR}/Info.plist")
  BACK_PROJ_DIR = Pathname.new("#{ORG_PROJ_DIR}/backup_xcodeproj")
  BACK_PROJ_FILE_PATH = Pathname.new("#{BACK_PROJ_DIR}/Unity-iPhone.xcodeproj")
  BACK_PROJ_PLIST_PATH = Pathname.new("#{BACK_PROJ_DIR}/Info.plist")

  def ipa_config
    @ipa_config ||= IPA_CONFIG
  end

  def get_ipa_config(name)
    ipa_config[name]
  end

  def get_ipa_args(name)
    cfg = get_ipa_config(name)
    args = [
      cfg['scheme'],
      cfg['loc'],
      cfg['usage'],
      cfg['plist'],
      cfg['project'],
      cfg['name'],
      cfg['version'],
      cfg['build_num'],
      cfg['bundle_id'],
      cfg['provision'],
      cfg['build_mode'],
      "'#{cfg['sign']}'",
      cfg['export_opts'],
    ]

    return args.join(' ')
  end

  def process_sdk(cfg)
    sdk_name = cfg['sdk']
    return '' if sdk_name.nil?

    if sdk_name == 'standard'
      return process_standard(cfg)
    else
      return ''
    end
  end

  def copy_sdk_files(sdk_name)
    sdk_folder = "#{ORG_PROJ_DIR}/projects/#{sdk_name}"

    # copy all items from sdk folder to project folder
    Dir.glob("#{sdk_folder}/*") do |f|
      puts "copy #{f} to #{ORG_PROJ_DIR}"
      FileUtils.cp_r(f, "#{ORG_PROJ_DIR}/")
    end
  end

  def checkout_folder(proj_path)
    cmd = "git checkout -- '#{proj_path}'"
    puts cmd
    system(cmd)
  end

  def restore_xcodeproj()

    ############################################
    # we consider standard version is 'CLEAN'
    copy_sdk_files('standard')
    ############################################


    # checkout changed files and folders
    checkout_folder("#{ORG_PROJ_DIR}/Unity-iPhone.xcodeproj/project.pbxproj")
    checkout_folder("#{ORG_PROJ_DIR}/Unity-iPhone")
  end

  def disp_copy_sdk()
    # add frameworks to xcodeproj
    require 'xcodeproj'
    proj_path = "#{ORG_PROJ_DIR}/Unity-iPhone copy.xcodeproj"
    proj = Xcodeproj::Project.open(proj_path)

    fwgroup = proj.main_group['Frameworks']
    fvsdk_group = fwgroup['fvsdk']
    puts "fvsdk files"
    fvsdk_group.files.each do |f|
      puts "#{f.name} - #{f.path} - #{f.comments}"
      f.build_files.each do |bf|
        puts "  #{bf.to_hash} - #{bf.settings} - #{bf.file_ref.parent.name} - #{bf.file_ref.parent.path}"
      end
    end


  end

  def process_standard(cfg)
    sdk_folder = "#{ORG_PROJ_DIR}/projects/#{cfg['sdk']}"

    # copy all items from sdk folder to project folder
    copy_sdk_files(cfg['sdk'])


    # modify Info.plist
  end

  task :bundle do
    system "bundle install --local >/dev/null"
  end

  IPA_CONFIG.each do |k, _|
    desc "build ipa for #{k}"
    task k => :bundle do

      cfg = get_ipa_config(k)
      process_sdk(cfg)

      ipa_args = get_ipa_args(k)

      if cfg['game_config_scheme']
        ENV['RS_CONFIG_SCHEME'] = cfg['game_config_scheme']
      else
        ENV['RS_CONFIG_SCHEME'] = 'default'
      end

      if cfg['bundle_root'] && cfg['bundle_root'] != 'master' then
        system(%{KOF_BUNDLE_IOS=$KOF_ART/AssetBundles-#{cfg['bundle_root']}/ios $RU/package.sh #{ipa_args}})
      else
        system("$RU/package.sh #{ipa_args}")
      end

      restore_xcodeproj()

    end

    desc "build ipa for #{k}"
    task "switch_proj_#{k}" do
      cfg = get_ipa_config(k)
      process_sdk(cfg)
    end
  end

  desc "restore xcodeproj to original"
  task "restore_xcodeproj" do
    restore_xcodeproj()
  end


  # desc "disp xcodeproj"
  # task "disp" do
  #   disp_copy_sdk()
  # end

end
