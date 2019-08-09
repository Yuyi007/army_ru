// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|custl-4864-OUT,alpha-1057-A;n:type:ShaderForge.SFN_Tex2d,id:6452,x:32337,y:32738,varname:node_6452,prsc:2,ntxv:0,isnm:False|UVIN-8992-UVOUT,TEX-2839-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2839,x:31970,y:32557,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_2839,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8859,x:32337,y:32884,varname:node_8859,prsc:2,ntxv:0,isnm:False|UVIN-1739-UVOUT,TEX-2839-TEX;n:type:ShaderForge.SFN_Color,id:4812,x:32351,y:32547,ptovrint:False,ptlb:color,ptin:_color,varname:node_4812,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:8512,x:32762,y:32622,varname:node_8512,prsc:2|A-6452-R,B-4812-RGB;n:type:ShaderForge.SFN_Multiply,id:3890,x:32762,y:32752,varname:node_3890,prsc:2|A-8859-G,B-4812-RGB;n:type:ShaderForge.SFN_Add,id:4864,x:32965,y:32752,varname:node_4864,prsc:2|A-8512-OUT,B-3890-OUT,C-117-OUT;n:type:ShaderForge.SFN_TexCoord,id:9412,x:31710,y:32734,varname:node_9412,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8992,x:32047,y:32736,varname:node_8992,prsc:2,spu:1,spv:0|UVIN-9412-UVOUT,DIST-8767-OUT;n:type:ShaderForge.SFN_Panner,id:1739,x:32047,y:32886,varname:node_1739,prsc:2,spu:-1,spv:0|UVIN-9412-UVOUT,DIST-8767-OUT;n:type:ShaderForge.SFN_Time,id:6467,x:31464,y:32904,varname:node_6467,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8767,x:31710,y:32904,varname:node_8767,prsc:2|A-6467-TSL,B-181-OUT;n:type:ShaderForge.SFN_Slider,id:181,x:31323,y:33058,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_181,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:60;n:type:ShaderForge.SFN_Tex2d,id:1057,x:32337,y:33033,varname:node_1057,prsc:2,ntxv:0,isnm:False|TEX-2839-TEX;n:type:ShaderForge.SFN_Multiply,id:117,x:32762,y:32895,varname:node_117,prsc:2|A-4812-RGB,B-1057-A;proporder:2839-4812-181;pass:END;sub:END;*/

Shader "Car/goal2" {
    Properties {
        _tex ("tex", 2D) = "white" {}
        [HDR]_color ("color", Color) = (1,1,1,1)
        _speed ("speed", Range(0, 60)) = 0
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform float4 _color;
            uniform float _speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float4 node_6467 = _Time;
                float node_8767 = (node_6467.r*_speed);
                float2 node_8992 = (i.uv0+node_8767*float2(1,0));
                float4 node_6452 = tex2D(_tex,TRANSFORM_TEX(node_8992, _tex));
                float2 node_1739 = (i.uv0+node_8767*float2(-1,0));
                float4 node_8859 = tex2D(_tex,TRANSFORM_TEX(node_1739, _tex));
                float4 node_1057 = tex2D(_tex,TRANSFORM_TEX(i.uv0, _tex));
                float3 finalColor = ((node_6452.r*_color.rgb)+(node_8859.g*_color.rgb)+(_color.rgb*node_1057.a));
                fixed4 finalRGBA = fixed4(finalColor,node_1057.a);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
