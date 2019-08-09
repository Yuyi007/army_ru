// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.625,fgcg:0.5540061,fgcb:0.4641544,fgca:1,fgde:0.05,fgrn:-50,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33323,y:32689,varname:node_9361,prsc:2|custl-2372-OUT;n:type:ShaderForge.SFN_TexCoord,id:1678,x:31624,y:32768,varname:node_1678,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:2216,x:33018,y:33252,varname:node_2216,prsc:2|A-3323-OUT,B-4711-OUT;n:type:ShaderForge.SFN_Trunc,id:4619,x:31118,y:33213,varname:node_4619,prsc:2|IN-8752-TTR;n:type:ShaderForge.SFN_RemapRange,id:8260,x:32209,y:32904,varname:node_8260,prsc:2,frmn:0,frmx:1,tomn:0,tomx:3.1415|IN-8375-OUT;n:type:ShaderForge.SFN_Sin,id:5398,x:32393,y:32904,varname:node_5398,prsc:2|IN-8260-OUT;n:type:ShaderForge.SFN_Panner,id:9933,x:31864,y:32904,varname:node_9933,prsc:2,spu:1,spv:1|UVIN-1678-UVOUT,DIST-3474-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8375,x:32035,y:32904,varname:node_8375,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-9933-UVOUT;n:type:ShaderForge.SFN_Power,id:3090,x:32462,y:33076,varname:node_3090,prsc:2|VAL-5398-OUT,EXP-6263-OUT;n:type:ShaderForge.SFN_Vector1,id:6263,x:32279,y:33095,varname:node_6263,prsc:2,v1:5.3;n:type:ShaderForge.SFN_Clamp,id:1487,x:32645,y:33076,varname:node_1487,prsc:2|IN-3090-OUT,MIN-6182-OUT,MAX-174-OUT;n:type:ShaderForge.SFN_Vector1,id:6182,x:32320,y:33311,varname:node_6182,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Vector1,id:174,x:32320,y:33389,varname:node_174,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:2372,x:33070,y:32890,varname:node_2372,prsc:2|A-7271-OUT,B-2216-OUT;n:type:ShaderForge.SFN_Color,id:404,x:32638,y:32613,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_404,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9926471,c2:0.431288,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:3323,x:32545,y:33486,ptovrint:False,ptlb:Select,ptin:_Select,varname:node_3323,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.5,max:1;n:type:ShaderForge.SFN_Posterize,id:4711,x:32645,y:33267,varname:node_4711,prsc:2|IN-1487-OUT,STPS-853-OUT;n:type:ShaderForge.SFN_Time,id:8752,x:30911,y:33166,varname:node_8752,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3474,x:31346,y:33190,varname:node_3474,prsc:2|A-872-OUT,B-4619-OUT;n:type:ShaderForge.SFN_Vector1,id:853,x:32320,y:33462,varname:node_853,prsc:2,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:872,x:31118,y:33142,ptovrint:False,ptlb:Num,ptin:_Num,varname:node_872,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:5438,x:32653,y:32790,ptovrint:False,ptlb:Tex,ptin:_Tex,varname:node_5438,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6d01a21a17d91884c978b5531450a329,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7271,x:32889,y:32790,varname:node_7271,prsc:2|A-404-RGB,B-5438-RGB;proporder:404-3323-872-5438;pass:END;sub:END;*/

Shader "Car/JianTou" {
    Properties {
        [HDR]_Color ("Color", Color) = (0.9926471,0.431288,0,1)
        _Select ("Select", Range(-1, 1)) = 0.5
        _Num ("Num", Float ) = 0
        _Tex ("Tex", 2D) = "white" {}
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
            uniform float4 _Color;
            uniform float _Select;
            uniform float _Num;
            uniform sampler2D _Tex; uniform float4 _Tex_ST;
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
                float4 _Tex_var = tex2D(_Tex,TRANSFORM_TEX(i.uv0, _Tex));
                float4 node_8752 = _Time;
                float node_853 = 2.0;
                float3 finalColor = ((_Color.rgb*_Tex_var.rgb)+(_Select*floor(clamp(pow(sin(((i.uv0+(_Num*trunc(node_8752.a))*float2(1,1)).g*3.1415+0.0)),5.3),0.01,1.0) * node_853) / (node_853 - 1)));
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
