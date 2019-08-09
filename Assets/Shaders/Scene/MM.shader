// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
Shader "Mobile/Mobile_Emission" {
Properties {
    [HDR]_Emission_Color("Color(RGB)", COLOR) = (1,1,1,1)
    _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
    Tags {"RenderType"="Opaque" }
    LOD 120
    Cull Back 

CGPROGRAM
#pragma surface surf Lambert noforwardadd

sampler2D _MainTex;
uniform float4 _Emission_Color;

struct Input {
    float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

    if(c.a > 0.15)
        o.Albedo = c.rgb * (_Emission_Color.rgb * c.a);
    else
        o.Albedo = c.rgb;
     
    o.Alpha = 1;
}
ENDCG
}

Fallback "Mobile/VertexLit"
}
