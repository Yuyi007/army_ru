#!/usr/bin/env ruby
# tencent_cdn_clean.rb

require 'rubygems'
require 'uri'
require 'cgi'
require 'json'
require 'digest/md5'
require 'net/http'
require 'em-http'
require 'base64'
require 'open-uri'
require 'openssl'
require 'erb'

if ARGV.length < 4
  puts "Usage: tencent_cdn_clean.rb appId secretId secretKey bucket"
  exit 0
end

Dir.chdir(File.expand_path(File.dirname(__FILE__)))

OpenSSL::SSL::VERIFY_PEER = OpenSSL::SSL::VERIFY_NONE

APPID = ARGV[0]
SECRET_ID = ARGV[1]
SECRET_KEY = ARGV[2]
BUCKET = ARGV[3]
DRY_RUN = false

COS_RM_CONFIG = {
  'appid' => APPID,
  'secret_id' => SECRET_ID,
  'secret_key' => SECRET_KEY,
}

def rewrite_config()
  puts "======================================================================="
  puts "rewriting config..."

  File.open('cos_rm_recursive/app_conf.json', 'w+') { |f| f.puts(JSON.generate(COS_RM_CONFIG)) }
  File.open('cos_rm_recursive/app_config.json', 'w+') { |f| f.puts(JSON.generate(COS_RM_CONFIG)) }
end

def clean_folders()
  puts "======================================================================="
  puts "cleaning old cos files..."

  # keep the latest 3 folders
  cmd = "cd cos_rm_recursive; python ./clean_folders.py #{BUCKET} 3"
  res = system(cmd)

  if not res then
    puts "clean_folders: failed!"
  end
end

def delete_cos_version(version)
  puts "delete_cos_version: deleting #{version}..."
  cmd = "cd cos_rm_recursive; python ./rm_recursive.py #{BUCKET} #{version}"
  if DRY_RUN then
    puts cmd
    res = false
  else
    res = system(cmd)
  end

  if not res then
    puts "delete_cos_version: delete #{version} failed!"
  end
end

if DRY_RUN then puts "Note this is a Dry Run !!!" end

rewrite_config()
clean_folders()
# delete_cos_version('')
