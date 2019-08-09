require_relative 'efx_lod_editor'

class EfxLodStripper
  attr_accessor :source_folder
  attr_accessor :mid_dest_folder
  attr_accessor :low_dest_folder
  attr_accessor :mid_suffix
  attr_accessor :low_suffix

  def initialize()

  end

  def start(&blk)
    strip_efxs()
    yield if block_given?
  end

  def strip_efxs()
    system("mkdir -p #{@mid_dest_folder}")
    system("mkdir -p #{@low_dest_folder}")

    files = get_asset_files("#{source_folder}/*.prefab")
    files.each do |fn|
      # next unless fn['cs_assistant_npc001']

      puts "processing efx lod for: #{fn}"

      pn = Pathname.new(fn)
      fcontent = IO.read(pn)
      ele = EfxLodEditor.new(fcontent)
      fc, mc, lc = ele.get_lod_files_contents()

      mid_file = "#{@mid_dest_folder}/#{pn.basename('.prefab')}#{@mid_suffix}.prefab"
      low_file = "#{@low_dest_folder}/#{pn.basename('.prefab')}#{@low_suffix}.prefab"

      if mc
        IO.write(mid_file, mc)
      else
        if File.exist?(mid_file)
          puts "no lod2 found, deleting #{mid_file}"
          File.delete(mid_file)
        end
      end

      if lc
        IO.write(low_file, lc)
      else
        if File.exist?(low_file)
          puts "no lod1 found, deleting #{low_file}"
          File.delete(low_file)
        end
      end
    end
  end

  def get_asset_files(pattern)
    FileList[pattern]
  end

end