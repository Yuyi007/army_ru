// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-1970-OUT;n:type:ShaderForge.SFN_Time,id:8287,x:31926,y:33004,varname:node_8287,prsc:2;n:type:ShaderForge.SFN_Sin,id:8247,x:32120,y:33004,varname:node_8247,prsc:2|IN-8287-TTR;n:type:ShaderForge.SFN_Vector1,id:2272,x:32186,y:33154,varname:node_2272,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:3997,x:32368,y:33026,varname:node_3997,prsc:2|A-8247-OUT,B-2272-OUT;n:type:ShaderForge.SFN_Multiply,id:4542,x:32634,y:33061,varname:node_4542,prsc:2|A-3997-OUT,B-2956-OUT;n:type:ShaderForge.SFN_Vector1,id:2956,x:32368,y:33209,varname:node_2956,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:3442,x:32824,y:33036,varname:node_3442,prsc:2|A-4542-OUT,B-2844-OUT;n:type:ShaderForge.SFN_Vector1,id:2844,x:32743,y:33206,varname:node_2844,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1970,x:32995,y:32953,varname:node_1970,prsc:2|A-978-RGB,B-3442-OUT;n:type:ShaderForge.SFN_Color,id:978,x:32820,y:32826,ptovrint:False,ptlb:node_978,ptin:_node_978,varname:node_978,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:978;pass:END;sub:END;*/

Shader "Car/Lamp" {
    Properties {
        [HDR]_node_978 ("node_978", Color) = (0.5,0.5,0.5,1)
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
            uniform float4 _node_978;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_8287 = _Time;
                float3 emissive = (_node_978.rgb*(((sin(node_8287.a)+1.0)*0.2)+1.0));
                float3 finalColor = emissive;
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
