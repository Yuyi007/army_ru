// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:32732,y:32617,varname:node_9361,prsc:2|custl-1559-OUT;n:type:ShaderForge.SFN_Tex2d,id:2341,x:31872,y:32583,ptovrint:False,ptlb:T2D,ptin:_T2D,varname:node_2341,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:43ca9a1dd6cf14c419f6fb2f3c2bc9f9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:1559,x:32471,y:32799,varname:node_1559,prsc:2|A-2341-RGB,B-1683-OUT;n:type:ShaderForge.SFN_Color,id:1877,x:31872,y:32975,ptovrint:False,ptlb:lampColor,ptin:_lampColor,varname:node_1877,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:1683,x:32304,y:32900,varname:node_1683,prsc:2|A-5545-OUT,B-1877-RGB,C-5183-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:8841,x:31872,y:32787,varname:node_8841,prsc:2,min:0,max:1|IN-2341-A;n:type:ShaderForge.SFN_OneMinus,id:5545,x:32080,y:32787,varname:node_5545,prsc:2|IN-8841-OUT;n:type:ShaderForge.SFN_Slider,id:694,x:31475,y:32967,ptovrint:False,ptlb:breathingS,ptin:_breathingS,varname:node_694,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.3,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:4686,x:31219,y:33374,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_4686,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Time,id:560,x:31298,y:33158,varname:node_560,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5586,x:31603,y:33179,varname:node_5586,prsc:2|A-560-T,B-4686-OUT;n:type:ShaderForge.SFN_Sin,id:2941,x:31872,y:33169,varname:node_2941,prsc:2|IN-5586-OUT;n:type:ShaderForge.SFN_Clamp,id:5183,x:32098,y:33169,varname:node_5183,prsc:2|IN-2941-OUT,MIN-1494-OUT,MAX-6868-OUT;n:type:ShaderForge.SFN_Vector1,id:1494,x:31805,y:33376,varname:node_1494,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:6868,x:31975,y:33376,varname:node_6868,prsc:2,v1:2;proporder:2341-1877-694-4686;pass:END;sub:END;*/

Shader "ww/ground-lamp" {
    Properties {
        _T2D ("T2D", 2D) = "white" {}
        [HDR]_lampColor ("lampColor", Color) = (1,1,1,1)
        _breathingS ("breathingS", Range(0.3, 1)) = 1
        _speed ("speed", Range(0, 10)) = 0
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
            uniform sampler2D _T2D; uniform float4 _T2D_ST;
            uniform float4 _lampColor;
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
                float4 _T2D_var = tex2D(_T2D,TRANSFORM_TEX(i.uv0, _T2D));
                float4 node_560 = _Time;
                float3 finalColor = (_T2D_var.rgb+((1.0 - clamp(_T2D_var.a,0,1))*_lampColor.rgb*clamp(sin((node_560.g*_speed)),0.5,2.0)));
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
