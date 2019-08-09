Shader "Scene/wave" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Strength ("Strength", Range(0, 1)) = 0.5
        _Speed ("Speed", Range(0, 5)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Strength;
            uniform float _Speed;

            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 color : COLOR;
               };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };

            VertexOutput vert (VertexInput v)
            {   
                VertexOutput o = (VertexOutput)0;

                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);

                
                float4 t = _Time;
                float x = sin(t.g * _Speed + v.color.r);
                float offset = x * (v.color.a - 1.0) * _Strength;
                v.vertex.xyz += v.normal * offset;
                o.pos = UnityObjectToClipPos( v.vertex );

                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;

                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                fixed4 finalRGBA = fixed4(_Diffuse_var.rgb,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);

                return finalRGBA;
            }
            ENDCG
        }
        
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
