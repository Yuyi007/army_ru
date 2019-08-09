// Simplified Diffuse shader. Differences from regular Diffuse one:
// - no Main Color
// - fully supports only 1 directional light. Other lights can affect it, but it will be per-vertex/SH.

Shader "Mobile/Diffuse-Alphablend" {
Properties {
	_MainTex ("Base (RGBA)", 2D) = "white" {}
    _MainColor("MainColor(RGB)", Color) = (1,1,1,1)
}
SubShader {
	Tags { "Queue"="Transparent" "RenderType"="Transparent" }
    Cull Off
    ZWrite Off
    Blend SrcAlpha OneMinusSrcAlpha
	LOD 150

CGPROGRAM
#pragma surface surf Lambert noforwardadd alpha:blend

sampler2D _MainTex;
float4 _MainColor;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
	o.Albedo = c.rgb * _MainColor;   
	o.Alpha = c.a;
}
ENDCG
}

Fallback "Mobile/VertexLit"
}
