// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33154,y:32470,varname:node_9361,prsc:2|custl-941-OUT,alpha-1165-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32070,y:32154,varname:node_851,prsc:2,ntxv:0,isnm:False|UVIN-7479-UVOUT,TEX-4763-TEX;n:type:ShaderForge.SFN_Color,id:5927,x:32070,y:31963,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:544,x:32484,y:32235,cmnt:Diffuse Color,varname:node_544,prsc:2|A-2698-OUT,B-5927-RGB,C-289-OUT;n:type:ShaderForge.SFN_TexCoord,id:9967,x:31442,y:32209,varname:node_9967,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:7479,x:31761,y:32210,varname:node_7479,prsc:2,spu:1,spv:1|UVIN-9967-UVOUT,DIST-9701-OUT;n:type:ShaderForge.SFN_Slider,id:8408,x:30740,y:32743,ptovrint:False,ptlb:panner_slider,ptin:_panner_slider,varname:node_8408,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Time,id:2751,x:30897,y:32589,varname:node_2751,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6408,x:31103,y:32663,varname:node_6408,prsc:2|A-2751-TSL,B-8408-OUT;n:type:ShaderForge.SFN_Slider,id:9594,x:31910,y:33214,ptovrint:False,ptlb:opactiy_slider,ptin:_opactiy_slider,varname:node_9594,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:4763,x:31761,y:32045,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_4763,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7646,x:32070,y:32381,varname:node_7646,prsc:2,ntxv:0,isnm:False|UVIN-7861-UVOUT,TEX-4763-TEX;n:type:ShaderForge.SFN_Tex2d,id:9875,x:32056,y:32664,varname:node_9875,prsc:2,ntxv:0,isnm:False|UVIN-1140-UVOUT,TEX-4763-TEX;n:type:ShaderForge.SFN_Multiply,id:679,x:32504,y:32434,varname:node_679,prsc:2|A-3746-OUT,B-5927-RGB;n:type:ShaderForge.SFN_Multiply,id:4565,x:32485,y:32635,varname:node_4565,prsc:2|A-1689-OUT,B-5927-RGB,C-6806-OUT;n:type:ShaderForge.SFN_Add,id:6655,x:32775,y:32410,varname:node_6655,prsc:2|A-544-OUT,B-679-OUT,C-4565-OUT,D-2752-OUT;n:type:ShaderForge.SFN_Tex2d,id:3487,x:32129,y:33030,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_3487,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9701,x:31604,y:32391,varname:node_9701,prsc:2|A-6408-OUT,B-6376-X;n:type:ShaderForge.SFN_Multiply,id:6629,x:31604,y:32626,varname:node_6629,prsc:2|A-6408-OUT,B-6376-Y;n:type:ShaderForge.SFN_Panner,id:7861,x:31795,y:32626,varname:node_7861,prsc:2,spu:1,spv:1|UVIN-9967-UVOUT,DIST-6629-OUT;n:type:ShaderForge.SFN_Multiply,id:1926,x:31607,y:32955,varname:node_1926,prsc:2|A-6408-OUT,B-6376-Z;n:type:ShaderForge.SFN_Panner,id:1140,x:31791,y:32911,varname:node_1140,prsc:2,spu:1,spv:1|UVIN-9967-UVOUT,DIST-1926-OUT;n:type:ShaderForge.SFN_Multiply,id:1165,x:32632,y:32989,varname:node_1165,prsc:2|A-3487-A,B-9594-OUT;n:type:ShaderForge.SFN_Multiply,id:941,x:32823,y:32729,varname:node_941,prsc:2|A-6655-OUT,B-3487-A;n:type:ShaderForge.SFN_Clamp01,id:2698,x:32247,y:32175,varname:node_2698,prsc:2|IN-851-R;n:type:ShaderForge.SFN_Clamp01,id:3746,x:32247,y:32398,varname:node_3746,prsc:2|IN-7646-G;n:type:ShaderForge.SFN_Clamp01,id:1689,x:32241,y:32664,varname:node_1689,prsc:2|IN-9875-B;n:type:ShaderForge.SFN_Slider,id:2752,x:32084,y:32895,ptovrint:False,ptlb:gloss,ptin:_gloss,varname:node_2752,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Vector4Property,id:6376,x:31124,y:32483,ptovrint:False,ptlb:RGB_Speed,ptin:_RGB_Speed,varname:node_6376,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1,v2:1.17,v3:1.53,v4:0;n:type:ShaderForge.SFN_Vector1,id:289,x:32329,y:32303,varname:node_289,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:6806,x:32340,y:32761,varname:node_6806,prsc:2,v1:0.4;proporder:4763-3487-5927-8408-9594-2752-6376;pass:END;sub:END;*/

Shader "ui/ui_main_room_btn" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _mask ("mask", 2D) = "white" {}
        [HDR]_Color ("Color", Color) = (0.5,0.5,0.5,1)
        _panner_slider ("panner_slider", Range(-5, 5)) = 0
        _opactiy_slider ("opactiy_slider", Range(0, 1)) = 0.5
        _gloss ("gloss", Range(0, 1)) = 0.5
        _RGB_Speed ("RGB_Speed", Vector) = (1,1.17,1.53,0)
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
            uniform float4 _Color;
            uniform float _panner_slider;
            uniform float _opactiy_slider;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float _gloss;
            uniform float4 _RGB_Speed;
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
                float4 node_2751 = _Time;
                float node_6408 = (node_2751.r*_panner_slider);
                float2 node_7479 = (i.uv0+(node_6408*_RGB_Speed.r)*float2(1,1));
                float4 node_851 = tex2D(_MainTex,TRANSFORM_TEX(node_7479, _MainTex));
                float2 node_7861 = (i.uv0+(node_6408*_RGB_Speed.g)*float2(1,1));
                float4 node_7646 = tex2D(_MainTex,TRANSFORM_TEX(node_7861, _MainTex));
                float2 node_1140 = (i.uv0+(node_6408*_RGB_Speed.b)*float2(1,1));
                float4 node_9875 = tex2D(_MainTex,TRANSFORM_TEX(node_1140, _MainTex));
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float3 finalColor = (((saturate(node_851.r)*_Color.rgb*0.2)+(saturate(node_7646.g)*_Color.rgb)+(saturate(node_9875.b)*_Color.rgb*0.4)+_gloss)*_mask_var.a);
                fixed4 finalRGBA = fixed4(finalColor,(_mask_var.a*_opactiy_slider));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
