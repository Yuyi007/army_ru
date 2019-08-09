#!/usr/bin/env ruby
# tencent_cdn_deploy.rb
#
# Pre-requesities:
# pip install --user coscmd
#

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

if ARGV.length < 7
  puts "Usage: tencent_cdn_deploy.rb appId secretId secretKey bucket region publish_dir cos_dir cdn_url"
  exit 0
end

Dir.chdir(File.expand_path(File.dirname(__FILE__)))

OpenSSL::SSL::VERIFY_PEER = OpenSSL::SSL::VERIFY_NONE

APPID = ARGV[0]
SECRET_ID = ARGV[1]
SECRET_KEY = ARGV[2]
BUCKET = ARGV[3]
REGION = ARGV[4]
PUBLISH_DIR = ARGV[5]
COS_DIR = ARGV[6]
CDN_URL = ARGV[7]
DRY_RUN = false

COS_CMD_CONFIG = "[common]" +
  # old account (3409540772)
  "\nsecret_id = " + 'AKIDBg7Dm4ITYVj983i4wxt9xOxQbVp0AJLM' +
  "\nsecret_key = " + 'ckEck8oWe2wm3bFL6rQ7AhCpg4XwTrGy' +
  "\nappid = " + '1252093001' +
  # new account (tinglei8@qq.com)
  # "\nsecret_id = " + 'AKIDeAczGQBKanyq2CRD3odKH9ugJoBRKlrn' +
  # "\nsecret_key = " + '3CFCzqcDkBSabVSEt253rYCtaAZmuwv2' +
  # "\nappid = " + '1255700311' +
  "\nbucket = " + BUCKET +
  "\nregion = " + REGION +
  "\nmax_thread = 5" +
  "\npart_size = 1" +
  "\n"
COS_SYNC_CONFIG = {
  'appid' => APPID,
  'secret_id' => SECRET_ID,
  'secret_key' => SECRET_KEY,
  'bucket' => BUCKET,
  'timeout' => '600000', # set to infinite
  'thread_num' => '5',
  'delete_sync' => '1',
  'daemon_mode' => '0',
  'daemon_interval' => '60',
  'enable_https' => '0',
  'local_path' => PUBLISH_DIR,
  'cos_path' => "/#{COS_DIR}",
}
COS_RM_CONFIG = {
  'appid' => APPID,
  'secret_id' => SECRET_ID,
  'secret_key' => SECRET_KEY,
}

def rewrite_config()
  puts "======================================================================="
  puts "rewriting config..."

  File.open(File.expand_path('~/.cos.conf'), 'w+') { |f| f.puts(COS_CMD_CONFIG) }
  File.open('cos_sync/conf/config.json', 'w+') { |f| f.puts(JSON.generate(COS_SYNC_CONFIG)) }
  File.open('cos_rm_recursive/app_conf.json', 'w+') { |f| f.puts(JSON.generate(COS_RM_CONFIG)) }
  File.open('cos_rm_recursive/app_config.json', 'w+') { |f| f.puts(JSON.generate(COS_RM_CONFIG)) }
end

def upload_files()
  puts "======================================================================="
  puts "uploading files from #{PUBLISH_DIR} to bucket #{BUCKET}/#{COS_DIR}..."

  # cmd = "sh cos_sync/start_cos_sync.sh"
  cmd = "coscmd upload -r '" + PUBLISH_DIR + "' '" + COS_DIR + "'"

  if DRY_RUN then
    puts cmd
    return nil
  else
    return system(cmd)
  end
end

def sign(rand_num, timestamp, secret_id, secret_key, path)
  params ="Action=RefreshCdnDir&Nonce=#{rand_num}&SecretId=#{secret_id}&Timestamp=#{timestamp}&dirs.0=#{path}"
  host = "cdn.api.qcloud.com/v2/index.php"
  str="POST#{host}?#{params}"
  puts "str=#{str}"
  # str = 'POSTcdn.api.qcloud.com/v2/index.php?Action=DescribeCdnHosts&Nonce=13029&SecretId=AKIDT8G5AsY1D3MChWooNq1rFSw1fyBVCX9D&Timestamp=1463122059&limit=10&offset=0';
  digest = OpenSSL::Digest.new('sha1')
  hmac = OpenSSL::HMAC.new(secret_key, digest)
  hmac.update(str)
  sha1 = hmac.digest
  sig = Base64.encode64(sha1).strip
  puts "sig=#{sig}"
  sig
end

def refresh_cdn_dir()
  puts "======================================================================="
  puts "refresh cdn dir..."

  url = 'https://cdn.api.qcloud.com/v2/index.php'
  secret_id = 'AKIDBg7Dm4ITYVj983i4wxt9xOxQbVp0AJLM'
  secret_key = 'ckEck8oWe2wm3bFL6rQ7AhCpg4XwTrGy'
  path = "#{CDN_URL}/#{COS_DIR}"
  rand_num = rand(99999)
  timestamp = Time.now.to_i

  args = {}
  args[:Nonce] = rand_num
  args[:Timestamp] = timestamp
  args[:Action] = 'RefreshCdnDir'
  args[:SecretId] = secret_id
  args[:Signature] = sign(rand_num, timestamp, secret_id, secret_key, path)
  args['dirs.0'] = path

  puts "args=#{args}"

  if DRY_RUN then
    puts "url=#{url}"
    return nil
  end

  resp = Net::HTTP.post_form(URI.parse(url),args)
  resp_text = resp.body
  puts"resp:#{resp_text}"
end

def delete_old_cos_files()
  puts "======================================================================="
  puts "deleting old cos files..."

  all_versions_file = File.join(PUBLISH_DIR, 'all_versions.tmp')
  puts "delete_old_cos_files: looking for #{all_versions_file}... "
  if File.exist?(all_versions_file) then
    lines = File.readlines(all_versions_file)
    totalLines = lines.length
    keep = 3
    if totalLines > keep then
      remain_lines = []
      lines.each_with_index do |version, i|
        version = version.strip
        if version == '' then next end
        if i >= totalLines - keep then
          remain_lines << version
        else
          puts "delete_old_cos_files: deleting #{version}..."
          # cmd = "cd cos_rm_recursive; python ./rm_recursive.py #{BUCKET} #{version}"
          cmd = "coscmd delete -f -r '" + version + "'"
          if DRY_RUN then
            puts cmd
            res = false
          else
            res = system(cmd)
          end
          if not res then
            puts "delete_old_cos_files: delete #{version} failed!"
            remain_lines << version
          end
        end
      end
      puts "delete_old_cos_files: rewrite all_versions_file..."
      File.open(all_versions_file, 'w+') { |f| f.puts remain_lines.join("\n") }
    else
      puts "delete_old_cos_files: total versions=#{lines.length}"
    end
    system("cat #{all_versions_file}")
  else
    puts "delete_old_cos_files: all_versions_file not found"
  end
end

if DRY_RUN then puts "Note this is a Dry Run !!!" end

rewrite_config()
upload_files()
refresh_cdn_dir()
delete_old_cos_files()
