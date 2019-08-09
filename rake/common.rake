
def art_dir; Boot::Tools.config.art_root; end

def unity_dir; ENV['LAU']; end

def luaext_dir; ENV['LUAEXT']; end

def lua_path
  File.expand_path(File.join(Boot::Tools.config.project_root,
    '/Assets/StreamingAssets/cl.lc'))
end

def config_lua_path
  File.expand_path(File.join(Boot::Tools.config.project_root,
    '/Assets/StreamingAssets/config.lua'))
end

def config_json_path
  File.expand_path(File.join(Boot::Tools.config.project_root,
    '/Assets/StreamingAssets/config.json'))
end

def string_json_path
  File.expand_path(File.join(Boot::Tools.config.project_root,
    '/Assets/StreamingAssets/strings.json'))
end

def ios_bundle_root
  if ENV['ZH_BUNDLE_IOS'].to_s.empty?
    Boot::Tools.config.ios_bundle_root
  else
    ENV['ZH_BUNDLE_IOS']
  end
end

def android_bundle_root
  if ENV['ZH_BUNDLE_ANDROID'].to_s.empty?
    Boot::Tools.config.android_bundle_root
  else
    ENV['ZH_BUNDLE_ANDROID']
  end
end

def art_root
  Boot::Tools.config.art_root
end

