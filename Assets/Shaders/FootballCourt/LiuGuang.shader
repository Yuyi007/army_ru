// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33312,y:32603,varname:node_9361,prsc:2|custl-7317-OUT;n:type:ShaderForge.SFN_TexCoord,id:4752,x:32278,y:32900,varname:node_4752,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:6060,x:32040,y:33057,varname:node_6060,prsc:2;n:type:ShaderForge.SFN_Color,id:5294,x:32716,y:32729,ptovrint:False,ptlb:BgColor,ptin:_BgColor,varname:node_5294,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:5984,x:32717,y:33073,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5984,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1359,x:33049,y:33011,varname:node_1359,prsc:2|A-5206-RGB,B-5984-RGB;n:type:ShaderForge.SFN_Add,id:7317,x:32975,y:32746,varname:node_7317,prsc:2|A-5294-RGB,B-1359-OUT;n:type:ShaderForge.SFN_Panner,id:6901,x:32496,y:32900,varname:node_6901,prsc:2,spu:1,spv:1|UVIN-4752-UVOUT,DIST-7420-OUT;n:type:ShaderForge.SFN_Slider,id:196,x:31903,y:33212,ptovrint:False,ptlb:PlaySpeed,ptin:_PlaySpeed,varname:node_196,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-30,cur:0,max:30;n:type:ShaderForge.SFN_Multiply,id:7420,x:32289,y:33057,varname:node_7420,prsc:2|A-6060-TSL,B-196-OUT;n:type:ShaderForge.SFN_Tex2d,id:5206,x:32717,y:32901,ptovrint:False,ptlb:node_5206,ptin:_node_5206,varname:node_5206,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ebe4332af709d744b903a62fd9950722,ntxv:0,isnm:False|UVIN-6901-UVOUT;proporder:5294-5984-196-5206;pass:END;sub:END;*/

Shader "Car/LiuGuang" {
    Properties {
        [HDR]_BgColor ("BgColor", Color) = (0.5,0.5,0.5,1)
        [HDR]_Color ("Color", Color) = (0.5,0.5,0.5,1)
        _PlaySpeed ("PlaySpeed", Range(-30, 30)) = 0
        _node_5206 ("node_5206", 2D) = "white" {}
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _BgColor;
            uniform float4 _Color;
            uniform float _PlaySpeed;
            uniform sampler2D _node_5206; uniform float4 _node_5206_ST;
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
                float4 node_6060 = _Time;
                float2 node_6901 = (i.uv0+(node_6060.r*_PlaySpeed)*float2(1,1));
                float4 _node_5206_var = tex2D(_node_5206,TRANSFORM_TEX(node_6901, _node_5206));
                float3 finalColor = (_BgColor.rgb+(_node_5206_var.rgb*_Color.rgb));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
