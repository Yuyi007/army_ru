// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:1,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33329,y:32408,varname:node_9361,prsc:2|custl-6730-OUT,alpha-777-OUT;n:type:ShaderForge.SFN_Depth,id:2734,x:32758,y:32561,varname:node_2734,prsc:2;n:type:ShaderForge.SFN_SceneDepth,id:1291,x:32758,y:32422,varname:node_1291,prsc:2|UV-4338-UVOUT;n:type:ShaderForge.SFN_ScreenPos,id:4338,x:32572,y:32422,varname:node_4338,prsc:2,sctp:2;n:type:ShaderForge.SFN_If,id:6730,x:32938,y:32649,varname:node_6730,prsc:2|A-1291-OUT,B-2734-OUT,GT-2672-RGB,EQ-2672-RGB,LT-7665-OUT;n:type:ShaderForge.SFN_Tex2d,id:2672,x:32412,y:32748,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_2672,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9930-UVOUT;n:type:ShaderForge.SFN_Color,id:7199,x:32412,y:32949,ptovrint:False,ptlb:color,ptin:_color,varname:node_7199,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9685,x:32756,y:32908,varname:node_9685,prsc:2|A-2672-RGB,B-7199-RGB,C-2967-OUT;n:type:ShaderForge.SFN_TexCoord,id:4901,x:31830,y:32849,varname:node_4901,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:4254,x:32145,y:33140,ptovrint:False,ptlb:tex-power,ptin:_texpower,varname:node_4254,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Time,id:5505,x:31745,y:33002,varname:node_5505,prsc:2;n:type:ShaderForge.SFN_Slider,id:4365,x:31613,y:33190,ptovrint:False,ptlb:tex-pan,ptin:_texpan,varname:node_4365,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:9998,x:31962,y:33028,varname:node_9998,prsc:2|A-5505-T,B-4365-OUT;n:type:ShaderForge.SFN_Tex2d,id:3853,x:32426,y:33303,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_3853,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3490-UVOUT;n:type:ShaderForge.SFN_Panner,id:3490,x:32235,y:33303,varname:node_3490,prsc:2,spu:0,spv:1|UVIN-4901-UVOUT,DIST-777-OUT;n:type:ShaderForge.SFN_Slider,id:777,x:31622,y:33515,ptovrint:False,ptlb:mask-pan,ptin:_maskpan,varname:node_777,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6,max:0.6;n:type:ShaderForge.SFN_Clamp,id:8214,x:32673,y:33303,varname:node_8214,prsc:2|IN-3853-RGB,MIN-6272-OUT,MAX-9358-OUT;n:type:ShaderForge.SFN_Multiply,id:2967,x:32573,y:33100,varname:node_2967,prsc:2|A-4254-OUT,B-8214-OUT;n:type:ShaderForge.SFN_Vector1,id:6272,x:32426,y:33473,varname:node_6272,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Vector1,id:9358,x:32426,y:33545,varname:node_9358,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:7665,x:32951,y:32952,varname:node_7665,prsc:2|A-9685-OUT,B-1496-RGB;n:type:ShaderForge.SFN_Color,id:1496,x:32756,y:33076,ptovrint:False,ptlb:bg-color,ptin:_bgcolor,varname:node_1496,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Panner,id:9930,x:32148,y:32853,varname:node_9930,prsc:2,spu:0,spv:1|UVIN-4901-UVOUT,DIST-9998-OUT;proporder:2672-4365-7199-4254-3853-777-1496;pass:END;sub:END;*/

Shader "car/zhedang" {
    Properties {
        _tex ("tex", 2D) = "white" {}
        _texpan ("tex-pan", Range(-1, 1)) = 0
        [HDR]_color ("color", Color) = (0.5,0.5,0.5,1)
        _texpower ("tex-power", Range(0, 1)) = 1
        _mask ("mask", 2D) = "white" {}
        _maskpan ("mask-pan", Range(0, 0.6)) = 0.6
        [HDR]_bgcolor ("bg-color", Color) = (0.5,0.5,0.5,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZTest GEqual
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles2 gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform float4 _color;
            uniform float _texpower;
            uniform float _texpan;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float _maskpan;
            uniform float4 _bgcolor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
                float node_6730_if_leA = step(max(0, LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sceneUVs.rg)) - _ProjectionParams.g),partZ);
                float node_6730_if_leB = step(partZ,max(0, LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sceneUVs.rg)) - _ProjectionParams.g));
                float4 node_5505 = _Time;
                float2 node_9930 = (i.uv0+(node_5505.g*_texpan)*float2(0,1));
                float4 _tex_var = tex2D(_tex,TRANSFORM_TEX(node_9930, _tex));
                float2 node_3490 = (i.uv0+_maskpan*float2(0,1));
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(node_3490, _mask));
                float3 finalColor = lerp((node_6730_if_leA*((_tex_var.rgb*_color.rgb*(_texpower*clamp(_mask_var.rgb,0.01,1.0)))+_bgcolor.rgb))+(node_6730_if_leB*_tex_var.rgb),_tex_var.rgb,node_6730_if_leA*node_6730_if_leB);
                fixed4 finalRGBA = fixed4(finalColor,_maskpan);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
