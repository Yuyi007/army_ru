// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33569,y:32524,varname:node_9361,prsc:2|custl-4365-OUT,alpha-8658-A;n:type:ShaderForge.SFN_Tex2d,id:8658,x:32914,y:32700,varname:node_8658,prsc:2,ntxv:0,isnm:False|UVIN-3482-UVOUT,TEX-1233-TEX;n:type:ShaderForge.SFN_TexCoord,id:9622,x:32093,y:32538,varname:node_9622,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:9126,x:31809,y:33250,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_9126,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:100;n:type:ShaderForge.SFN_Append,id:7791,x:32341,y:32561,varname:node_7791,prsc:2|A-9622-U,B-1461-OUT;n:type:ShaderForge.SFN_RemapRange,id:1461,x:32093,y:32711,varname:node_1461,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-9622-V;n:type:ShaderForge.SFN_UVTile,id:3482,x:32690,y:32565,varname:node_3482,prsc:2|UVIN-1775-UVOUT,WDT-3860-OUT,HGT-508-OUT,TILE-6216-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1233,x:32678,y:32741,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_1233,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Negate,id:508,x:32369,y:32815,varname:node_508,prsc:2|IN-2542-OUT;n:type:ShaderForge.SFN_Trunc,id:6216,x:32369,y:32974,varname:node_6216,prsc:2|IN-9673-OUT;n:type:ShaderForge.SFN_Multiply,id:9673,x:32188,y:33100,varname:node_9673,prsc:2|A-7310-T,B-9126-OUT;n:type:ShaderForge.SFN_Time,id:7310,x:31936,y:33080,varname:node_7310,prsc:2;n:type:ShaderForge.SFN_Multiply,id:491,x:33138,y:32534,varname:node_491,prsc:2|A-5337-RGB,B-8658-RGB;n:type:ShaderForge.SFN_Color,id:5337,x:32914,y:32534,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5337,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:2542,x:32065,y:32946,ptovrint:False,ptlb:H,ptin:_H,varname:node_2542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_ValueProperty,id:3860,x:32341,y:32736,ptovrint:False,ptlb:W,ptin:_W,varname:node_3860,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Rotator,id:1775,x:32517,y:32452,varname:node_1775,prsc:2|UVIN-7791-OUT,ANG-48-OUT;n:type:ShaderForge.SFN_Slider,id:48,x:32130,y:32396,ptovrint:False,ptlb:Angle,ptin:_Angle,varname:node_48,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-180,cur:0,max:180;n:type:ShaderForge.SFN_Power,id:386,x:32932,y:32914,varname:node_386,prsc:2|VAL-8658-RGB,EXP-2592-OUT;n:type:ShaderForge.SFN_Vector1,id:2592,x:32678,y:32948,varname:node_2592,prsc:2,v1:3;n:type:ShaderForge.SFN_OneMinus,id:2030,x:33100,y:32914,varname:node_2030,prsc:2|IN-386-OUT;n:type:ShaderForge.SFN_Color,id:1639,x:32948,y:33073,ptovrint:False,ptlb:W_Color,ptin:_W_Color,varname:node_1639,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2593,x:33278,y:33050,varname:node_2593,prsc:2|A-2030-OUT,B-1639-RGB;n:type:ShaderForge.SFN_Add,id:4365,x:33340,y:32628,varname:node_4365,prsc:2|A-491-OUT,B-2593-OUT;proporder:9126-1233-5337-2542-3860-48-1639;pass:END;sub:END;*/

Shader "Car/CarSmoke" {
    Properties {
        _Speed ("Speed", Range(0, 100)) = 0.8
        _Texture ("Texture", 2D) = "white" {}
        [HDR]_Color ("Color", Color) = (0.5,0.5,0.5,1)
        _H ("H", Float ) = 4
        _W ("W", Float ) = 4
        _Angle ("Angle", Range(-180, 180)) = 0
        _W_Color ("W_Color", Color) = (0.5,0.5,0.5,1)
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float _Speed;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _Color;
            uniform float _H;
            uniform float _W;
            uniform float _Angle;
            uniform float4 _W_Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float4 node_7310 = _Time;
                float node_6216 = trunc((node_7310.g*_Speed));
                float2 node_3482_tc_rcp = float2(1.0,1.0)/float2( _W, (-1*_H) );
                float node_3482_ty = floor(node_6216 * node_3482_tc_rcp.x);
                float node_3482_tx = node_6216 - _W * node_3482_ty;
                float node_1775_ang = _Angle;
                float node_1775_spd = 1.0;
                float node_1775_cos = cos(node_1775_spd*node_1775_ang);
                float node_1775_sin = sin(node_1775_spd*node_1775_ang);
                float2 node_1775_piv = float2(0.5,0.5);
                float2 node_1775 = (mul(float2(i.uv0.r,(i.uv0.g*-1.0+1.0))-node_1775_piv,float2x2( node_1775_cos, -node_1775_sin, node_1775_sin, node_1775_cos))+node_1775_piv);
                float2 node_3482 = (node_1775 + float2(node_3482_tx, node_3482_ty)) * node_3482_tc_rcp;
                float4 node_8658 = tex2D(_Texture,TRANSFORM_TEX(node_3482, _Texture));
                float3 finalColor = ((_Color.rgb*node_8658.rgb)+((1.0 - pow(node_8658.rgb,3.0))*_W_Color.rgb));
                return fixed4(finalColor,node_8658.a);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
