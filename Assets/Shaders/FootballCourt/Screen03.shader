// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-5634-OUT,alpha-3696-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32130,y:32348,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1ffe62dff3c822948930935362223dfe,ntxv:0,isnm:False|UVIN-61-UVOUT;n:type:ShaderForge.SFN_Color,id:5927,x:32384,y:32793,ptovrint:False,ptlb:BgColor,ptin:_BgColor,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:226,x:32328,y:33005,ptovrint:False,ptlb:EmissionSlide,ptin:_EmissionSlide,varname:node_226,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:3696,x:32864,y:32972,varname:node_3696,prsc:2,v1:0.6;n:type:ShaderForge.SFN_TexCoord,id:9121,x:31504,y:32323,varname:node_9121,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3908,x:31758,y:32348,varname:node_3908,prsc:2|A-9121-UVOUT,B-3530-OUT;n:type:ShaderForge.SFN_Vector2,id:3530,x:31504,y:32480,varname:node_3530,prsc:2,v1:4,v2:1;n:type:ShaderForge.SFN_Add,id:5634,x:32846,y:32809,varname:node_5634,prsc:2|A-4238-OUT,B-5927-RGB,C-226-OUT;n:type:ShaderForge.SFN_Color,id:915,x:31957,y:32643,ptovrint:False,ptlb:DiffuseColor,ptin:_DiffuseColor,varname:node_915,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.3803245,c3:0.04411763,c4:1;n:type:ShaderForge.SFN_Multiply,id:4238,x:32586,y:32517,varname:node_4238,prsc:2|A-851-A,B-915-RGB;n:type:ShaderForge.SFN_Panner,id:61,x:31946,y:32348,varname:node_61,prsc:2,spu:1,spv:0|UVIN-3908-OUT,DIST-7727-OUT;n:type:ShaderForge.SFN_Slider,id:4631,x:31078,y:32631,ptovrint:False,ptlb:SpeedSlide,ptin:_SpeedSlide,varname:node_4631,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:100;n:type:ShaderForge.SFN_Time,id:457,x:31548,y:32792,varname:node_457,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7727,x:31757,y:32679,varname:node_7727,prsc:2|A-3280-OUT,B-457-TSL;n:type:ShaderForge.SFN_OneMinus,id:3280,x:31491,y:32629,varname:node_3280,prsc:2|IN-4631-OUT;proporder:851-5927-226-915-4631;pass:END;sub:END;*/

Shader "Car/Screen03" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _BgColor ("BgColor", Color) = (0,0,0,1)
        _EmissionSlide ("EmissionSlide", Range(0, 1)) = 0
        [HDR]_DiffuseColor ("DiffuseColor", Color) = (1,0.3803245,0.04411763,1)
        _SpeedSlide ("SpeedSlide", Range(1, 100)) = 1
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _BgColor;
            uniform float _EmissionSlide;
            uniform float4 _DiffuseColor;
            uniform float _SpeedSlide;
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
////// Emissive:
                float4 node_457 = _Time;
                float2 node_61 = ((i.uv0*float2(4,1))+((1.0 - _SpeedSlide)*node_457.r)*float2(1,0));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_61, _Diffuse));
                float3 emissive = ((_Diffuse_var.a*_DiffuseColor.rgb)+_BgColor.rgb+_EmissionSlide);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,0.6);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
