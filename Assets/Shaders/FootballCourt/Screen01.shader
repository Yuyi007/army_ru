// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32713,y:32543,varname:node_2865,prsc:2|emission-9994-OUT,custl-5127-OUT,alpha-5340-OUT,refract-109-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:31944,y:32434,varname:node_6343,prsc:2|A-8557-OUT,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31750,y:32614,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31301,y:32430,varname:_MainTex,prsc:2,ntxv:0,isnm:False|UVIN-653-OUT,TEX-497-TEX;n:type:ShaderForge.SFN_Vector1,id:5340,x:32451,y:33013,varname:node_5340,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Vector1,id:7310,x:32268,y:33246,varname:node_7310,prsc:2,v1:0.01;n:type:ShaderForge.SFN_TexCoord,id:5026,x:32268,y:33102,varname:node_5026,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:109,x:32498,y:33102,varname:node_109,prsc:2|A-5026-UVOUT,B-7310-OUT;n:type:ShaderForge.SFN_Slider,id:3069,x:31443,y:33023,ptovrint:False,ptlb:Em_Slider,ptin:_Em_Slider,varname:node_3069,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:9994,x:31950,y:32972,varname:node_9994,prsc:2|A-3069-OUT,B-2818-OUT;n:type:ShaderForge.SFN_Fresnel,id:2818,x:31380,y:32806,varname:node_2818,prsc:2;n:type:ShaderForge.SFN_Slider,id:8467,x:31906,y:32690,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_8467,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.5,cur:0.5,max:5;n:type:ShaderForge.SFN_OneMinus,id:4346,x:31556,y:32806,varname:node_4346,prsc:2|IN-2818-OUT;n:type:ShaderForge.SFN_Multiply,id:6559,x:32178,y:32496,varname:node_6559,prsc:2|A-4346-OUT,B-6343-OUT,C-8467-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:497,x:30980,y:32554,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_497,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:3393,x:31228,y:31988,varname:node_3393,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:565,x:31409,y:31988,varname:node_565,prsc:2,spu:0,spv:1|UVIN-3393-UVOUT;n:type:ShaderForge.SFN_Add,id:3344,x:31651,y:32100,varname:node_3344,prsc:2|A-565-UVOUT,B-183-OUT;n:type:ShaderForge.SFN_Slider,id:7880,x:31005,y:32350,ptovrint:False,ptlb:ShakeSlide,ptin:_ShakeSlide,varname:node_7880,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.1,cur:0,max:0.1;n:type:ShaderForge.SFN_ToggleProperty,id:2866,x:31651,y:32257,ptovrint:False,ptlb:ShakeToggle,ptin:_ShakeToggle,varname:node_2866,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Multiply,id:653,x:31862,y:32197,varname:node_653,prsc:2|A-3344-OUT,B-2866-OUT;n:type:ShaderForge.SFN_Tex2d,id:8664,x:31301,y:32608,varname:node_8664,prsc:2,ntxv:0,isnm:False|TEX-497-TEX;n:type:ShaderForge.SFN_Add,id:8557,x:31750,y:32434,varname:node_8557,prsc:2|A-7736-RGB,B-8664-RGB;n:type:ShaderForge.SFN_Multiply,id:183,x:31397,y:32163,varname:node_183,prsc:2|A-7794-G,B-7880-OUT;n:type:ShaderForge.SFN_Tex2d,id:7794,x:31146,y:32163,ptovrint:False,ptlb:gl_Texture,ptin:_gl_Texture,varname:node_7794,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_If,id:5127,x:32431,y:32459,varname:node_5127,prsc:2|A-1333-OUT,B-2866-OUT,GT-3535-OUT,EQ-6559-OUT,LT-6559-OUT;n:type:ShaderForge.SFN_Vector1,id:1333,x:31862,y:32114,varname:node_1333,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3535,x:31985,y:32819,varname:node_3535,prsc:2|A-3371-OUT,B-8664-RGB;n:type:ShaderForge.SFN_Vector1,id:3371,x:31761,y:32886,varname:node_3371,prsc:2,v1:1.1;proporder:6665-8467-3069-497-7880-2866-7794;pass:END;sub:END;*/

Shader "Car/Screen01" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Gloss ("Gloss", Range(0.5, 5)) = 0.5
        _Em_Slider ("Em_Slider", Range(0, 1)) = 0
        _Texture ("Texture", 2D) = "white" {}
        _ShakeSlide ("ShakeSlide", Range(-0.1, 0.1)) = 0
        [MaterialToggle] _ShakeToggle ("ShakeToggle", Float ) = 0
        _gl_Texture ("gl_Texture", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _Color;
            uniform float _Em_Slider;
            uniform float _Gloss;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _ShakeSlide;
            uniform fixed _ShakeToggle;
            uniform sampler2D _gl_Texture; uniform float4 _gl_Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (i.uv0*0.01);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float node_2818 = (1.0-max(0,dot(normalDirection, viewDirection)));
                float node_9994 = (_Em_Slider*node_2818);
                float3 emissive = float3(node_9994,node_9994,node_9994);
                float node_5127_if_leA = step(1.0,_ShakeToggle);
                float node_5127_if_leB = step(_ShakeToggle,1.0);
                float4 node_7109 = _Time;
                float4 _gl_Texture_var = tex2D(_gl_Texture,TRANSFORM_TEX(i.uv0, _gl_Texture));
                float2 node_653 = (((i.uv0+node_7109.g*float2(0,1))+(_gl_Texture_var.g*_ShakeSlide))*_ShakeToggle);
                float4 _MainTex = tex2D(_Texture,TRANSFORM_TEX(node_653, _Texture));
                float4 node_8664 = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_6559 = ((1.0 - node_2818)*((_MainTex.rgb+node_8664.rgb)*_Color.rgb)*_Gloss);
                float3 finalColor = emissive + lerp((node_5127_if_leA*node_6559)+(node_5127_if_leB*(1.1*node_8664.rgb)),node_6559,node_5127_if_leA*node_5127_if_leB);
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,0.9),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float _Em_Slider;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_2818 = (1.0-max(0,dot(normalDirection, viewDirection)));
                float node_9994 = (_Em_Slider*node_2818);
                o.Emission = float3(node_9994,node_9994,node_9994);
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
