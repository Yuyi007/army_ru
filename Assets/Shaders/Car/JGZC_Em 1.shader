// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:34148,y:32688,varname:node_9361,prsc:2|emission-7115-OUT;n:type:ShaderForge.SFN_TexCoord,id:8709,x:32246,y:32670,varname:node_8709,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:6413,x:32417,y:32670,varname:node_6413,prsc:2,spu:-0.1,spv:-0.08|UVIN-8709-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9476,x:32619,y:32670,ptovrint:False,ptlb:raoluan,ptin:_raoluan,varname:node_9476,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6413-UVOUT;n:type:ShaderForge.SFN_Add,id:1975,x:32823,y:32776,varname:node_1975,prsc:2|A-9476-R,B-3116-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3116,x:32655,y:32843,varname:node_3116,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8777,x:32985,y:32804,varname:node_8777,prsc:2,spu:-0.5,spv:-0.2|UVIN-1975-OUT;n:type:ShaderForge.SFN_Tex2d,id:6608,x:33111,y:32935,ptovrint:False,ptlb:wl,ptin:_wl,varname:node_6608,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8777-UVOUT;n:type:ShaderForge.SFN_Power,id:6589,x:33277,y:32982,varname:node_6589,prsc:2|VAL-6608-RGB,EXP-5121-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5121,x:33035,y:33126,ptovrint:False,ptlb:power,ptin:_power,varname:node_5121,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:7115,x:33508,y:33042,varname:node_7115,prsc:2|A-6589-OUT,B-3392-OUT,C-5240-RGB;n:type:ShaderForge.SFN_ValueProperty,id:3392,x:33315,y:33168,ptovrint:False,ptlb:qd,ptin:_qd,varname:node_3392,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Color,id:5240,x:33377,y:33258,ptovrint:False,ptlb:node_5240,ptin:_node_5240,varname:node_5240,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:9476-6608-5121-3392-5240;pass:END;sub:END;*/

Shader "Car/JGZC_Em" {
    Properties {
        _raoluan ("raoluan", 2D) = "white" {}
        _wl ("wl", 2D) = "white" {}
        _power ("power", Float ) = 2
        _qd ("qd", Float ) = 5
        [HDR]_node_5240 ("node_5240", Color) = (0.5,0.5,0.5,1)
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
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform sampler2D _raoluan; uniform float4 _raoluan_ST;
            uniform sampler2D _wl; uniform float4 _wl_ST;
            uniform float _power;
            uniform float _qd;
            uniform float4 _node_5240;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_7474 = _Time;
                float2 node_6413 = (i.uv0+node_7474.g*float2(-0.1,-0.08));
                float4 _raoluan_var = tex2D(_raoluan,TRANSFORM_TEX(node_6413, _raoluan));
                float2 node_8777 = ((_raoluan_var.r+i.uv0)+node_7474.g*float2(-0.5,-0.2));
                float4 _wl_var = tex2D(_wl,TRANSFORM_TEX(node_8777, _wl));
                float3 emissive = (pow(_wl_var.rgb,_power)*_qd*_node_5240.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
