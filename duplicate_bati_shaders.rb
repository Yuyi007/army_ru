

def get_shader_name(idx)
  return "Assets/Resources/Shaders/Custom/Tex#{idx}.shader"
end

copy_from_file = IO.read(get_shader_name(1))

2.upto(7) do |idx|
  new_file = copy_from_file.gsub('Shader "Tex1"', "Shader \"Tex#{idx}\"")
  new_file = new_file.gsub('o.texcoord = TRANSFORM_TEX(v.texcoord, _Tex1);', "o.texcoord = TRANSFORM_TEX(v.texcoord, _Tex#{idx});")
  new_file = new_file.gsub('tex2D(_Tex1, i.texcoord)', "tex2D(_Tex#{idx}, i.texcoord)")
  new_file = new_file.gsub('_multColor1 * tex2D', "_multColor#{idx} * tex2D")
  IO.write(get_shader_name(idx), new_file)
end