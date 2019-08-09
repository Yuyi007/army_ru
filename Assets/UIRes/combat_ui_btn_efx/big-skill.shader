// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33043,y:33024,varname:node_9361,prsc:2|custl-4705-OUT,alpha-7404-A;n:type:ShaderForge.SFN_Tex2d,id:7456,x:32214,y:32940,ptovrint:False,ptlb:tex01,ptin:_tex01,varname:node_7456,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8866-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5838,x:31797,y:32940,varname:node_5838,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8866,x:31995,y:32940,varname:node_8866,prsc:2,spu:-0.3,spv:-1|UVIN-5838-UVOUT,DIST-1814-OUT;n:type:ShaderForge.SFN_Time,id:3902,x:31580,y:33048,varname:node_3902,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1814,x:31797,y:33112,varname:node_1814,prsc:2|A-3902-T,B-9351-OUT;n:type:ShaderForge.SFN_Slider,id:9351,x:31395,y:33288,ptovrint:False,ptlb:speed01,ptin:_speed01,varname:node_9351,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.120475,max:10;n:type:ShaderForge.SFN_Multiply,id:4672,x:31797,y:33256,varname:node_4672,prsc:2|A-3902-T,B-7056-OUT;n:type:ShaderForge.SFN_Slider,id:7056,x:31395,y:33394,ptovrint:False,ptlb:speed02,ptin:_speed02,varname:node_7056,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3571913,max:10;n:type:ShaderForge.SFN_Panner,id:142,x:32018,y:33187,varname:node_142,prsc:2,spu:-0.2,spv:-1|UVIN-5838-UVOUT,DIST-4672-OUT;n:type:ShaderForge.SFN_Multiply,id:1282,x:32436,y:32996,varname:node_1282,prsc:2|A-7456-RGB,B-7456-A;n:type:ShaderForge.SFN_Tex2d,id:7527,x:32214,y:33187,ptovrint:False,ptlb:tex02,ptin:_tex02,varname:node_7527,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-142-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7404,x:32214,y:33557,ptovrint:False,ptlb:mask-tex,ptin:_masktex,varname:node_7404,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2802,x:32436,y:33204,varname:node_2802,prsc:2|A-7527-RGB,B-7527-A;n:type:ShaderForge.SFN_Add,id:2151,x:32644,y:33072,varname:node_2151,prsc:2|A-1282-OUT,B-2802-OUT;n:type:ShaderForge.SFN_Color,id:3599,x:32214,y:33387,ptovrint:False,ptlb:main-color,ptin:_maincolor,varname:node_3599,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:4705,x:32830,y:33188,varname:node_4705,prsc:2|A-2151-OUT,B-3599-RGB;proporder:7456-7527-9351-7056-7404-3599;pass:END;sub:END;*/

Shader "GUI/BigSkill" {
    Properties {
        _tex01 ("tex01", 2D) = "white" {}
        _tex02 ("tex02", 2D) = "white" {}
        _speed01 ("speed01", Range(0, 10)) = 1.120475
        _speed02 ("speed02", Range(0, 10)) = 0.3571913
        _masktex ("mask-tex", 2D) = "white" {}
        [HDR]_maincolor ("main-color", Color) = (0.5,0.5,0.5,1)
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
            ZTest Always
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
            uniform sampler2D _tex01; uniform float4 _tex01_ST;
            uniform float _speed01;
            uniform float _speed02;
            uniform sampler2D _tex02; uniform float4 _tex02_ST;
            uniform sampler2D _masktex; uniform float4 _masktex_ST;
            uniform float4 _maincolor;
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
                float4 node_3902 = _Time;
                float2 node_8866 = (i.uv0+(node_3902.g*_speed01)*float2(-0.3,-1));
                float4 _tex01_var = tex2D(_tex01,TRANSFORM_TEX(node_8866, _tex01));
                float2 node_142 = (i.uv0+(node_3902.g*_speed02)*float2(-0.2,-1));
                float4 _tex02_var = tex2D(_tex02,TRANSFORM_TEX(node_142, _tex02));
                float3 finalColor = (((_tex01_var.rgb*_tex01_var.a)+(_tex02_var.rgb*_tex02_var.a))+_maincolor.rgb);
                float4 _masktex_var = tex2D(_masktex,TRANSFORM_TEX(i.uv0, _masktex));
                fixed4 finalRGBA = fixed4(finalColor,_masktex_var.a);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
