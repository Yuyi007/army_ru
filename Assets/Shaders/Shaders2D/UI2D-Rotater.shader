// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33332,y:32684,varname:node_9361,prsc:2|custl-1368-RGB;n:type:ShaderForge.SFN_TexCoord,id:3298,x:32571,y:32809,varname:node_3298,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Rotator,id:5303,x:32831,y:32915,varname:node_5303,prsc:2|UVIN-3298-UVOUT,ANG-1583-OUT;n:type:ShaderForge.SFN_Time,id:1537,x:32482,y:32965,varname:node_1537,prsc:2;n:type:ShaderForge.SFN_Slider,id:285,x:32325,y:33118,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_285,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:1583,x:32663,y:33028,varname:node_1583,prsc:2|A-1537-T,B-285-OUT;n:type:ShaderForge.SFN_Tex2d,id:1368,x:33074,y:32952,ptovrint:False,ptlb:node_1368,ptin:_node_1368,varname:node_1368,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5303-UVOUT;proporder:285-1368;pass:END;sub:END;*/

Shader "Car2D/UI-Rotater" {
    Properties {
        _speed ("speed", Range(-5, 5)) = 0
        _node_1368 ("node_1368", 2D) = "white" {}
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float _speed;
            uniform sampler2D _node_1368; uniform float4 _node_1368_ST;
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
                float4 node_1537 = _Time;
                float node_5303_ang = (node_1537.g*_speed);
                float node_5303_spd = 1.0;
                float node_5303_cos = cos(node_5303_spd*node_5303_ang);
                float node_5303_sin = sin(node_5303_spd*node_5303_ang);
                float2 node_5303_piv = float2(0.5,0.5);
                float2 node_5303 = (mul(i.uv0-node_5303_piv,float2x2( node_5303_cos, -node_5303_sin, node_5303_sin, node_5303_cos))+node_5303_piv);
                float4 _node_1368_var = tex2D(_node_1368,TRANSFORM_TEX(node_5303, _node_1368));
                float3 finalColor = _node_1368_var.rgb;
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
