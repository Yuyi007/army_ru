// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.625,fgcg:0.5540061,fgcb:0.4641544,fgca:1,fgde:0.05,fgrn:-50,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:32911,y:32587,varname:node_9361,prsc:2|custl-8549-OUT,alpha-9792-OUT;n:type:ShaderForge.SFN_Tex2d,id:4906,x:32210,y:32773,ptovrint:False,ptlb:Tex,ptin:_Tex,varname:node_4906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ec12e343c41c342489a9944683ce15b2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:2794,x:32210,y:32587,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2794,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.9172416,c4:1;n:type:ShaderForge.SFN_Multiply,id:761,x:32461,y:32587,varname:node_761,prsc:2|A-2794-RGB,B-4906-RGB;n:type:ShaderForge.SFN_TexCoord,id:8441,x:31875,y:33081,varname:node_8441,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Sin,id:9200,x:32426,y:33081,varname:node_9200,prsc:2|IN-1330-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2335,x:32068,y:33081,varname:node_2335,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8441-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:1330,x:32249,y:33081,varname:node_1330,prsc:2,frmn:0,frmx:1,tomn:0,tomx:3.14|IN-2335-OUT;n:type:ShaderForge.SFN_Add,id:8549,x:32671,y:32587,varname:node_8549,prsc:2|A-761-OUT,B-6068-OUT,C-1947-OUT;n:type:ShaderForge.SFN_Multiply,id:9792,x:32466,y:32846,varname:node_9792,prsc:2|A-4906-A,B-928-OUT;n:type:ShaderForge.SFN_Slider,id:928,x:32068,y:32958,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_928,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Tex2d,id:4393,x:31862,y:32190,ptovrint:False,ptlb:Shui,ptin:_Shui,varname:node_4393,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9767-UVOUT;n:type:ShaderForge.SFN_Power,id:6988,x:32155,y:32212,varname:node_6988,prsc:2|VAL-4393-R,EXP-714-OUT;n:type:ShaderForge.SFN_Vector1,id:714,x:31862,y:32409,varname:node_714,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:6068,x:32615,y:33081,varname:node_6068,prsc:2|A-9200-OUT,B-6661-OUT;n:type:ShaderForge.SFN_Vector1,id:6661,x:32441,y:33307,varname:node_6661,prsc:2,v1:0.5;n:type:ShaderForge.SFN_TexCoord,id:2281,x:31362,y:32192,varname:node_2281,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:1540,x:32155,y:32379,varname:node_1540,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Step,id:1947,x:32406,y:32255,varname:node_1947,prsc:2|A-6988-OUT,B-1540-OUT;n:type:ShaderForge.SFN_Panner,id:9767,x:31627,y:32190,varname:node_9767,prsc:2,spu:1,spv:1|UVIN-2281-UVOUT,DIST-7348-OUT;n:type:ShaderForge.SFN_Time,id:9543,x:31112,y:32345,varname:node_9543,prsc:2;n:type:ShaderForge.SFN_Slider,id:8708,x:30998,y:32539,ptovrint:False,ptlb:Panner,ptin:_Panner,varname:node_8708,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:7348,x:31362,y:32345,varname:node_7348,prsc:2|A-9543-TSL,B-8708-OUT;proporder:4906-2794-928-4393-8708;pass:END;sub:END;*/

Shader "Car/FootWall" {
    Properties {
        _Tex ("Tex", 2D) = "white" {}
        [HDR]_Color ("Color", Color) = (0,1,0.9172416,1)
        _Opacity ("Opacity", Range(0, 1)) = 0.5
        _Shui ("Shui", 2D) = "white" {}
        _Panner ("Panner", Range(-5, 5)) = 0
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform sampler2D _Tex; uniform float4 _Tex_ST;
            uniform float4 _Color;
            uniform float _Opacity;
            uniform sampler2D _Shui; uniform float4 _Shui_ST;
            uniform float _Panner;
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
                float4 node_9543 = _Time;
                float2 node_9767 = (i.uv0+(node_9543.r*_Panner)*float2(1,1));
                float4 _Shui_var = tex2D(_Shui,TRANSFORM_TEX(node_9767, _Shui));
                float3 finalColor = ((_Color.rgb*_Tex_var.rgb)+(sin((i.uv0.r*3.14+0.0))*0.5)+step(pow(_Shui_var.r,2.0),0.2));
                fixed4 finalRGBA = fixed4(finalColor,(_Tex_var.a*_Opacity));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
