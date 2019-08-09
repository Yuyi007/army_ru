// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33585,y:32135,varname:node_9361,prsc:2|custl-4021-OUT,alpha-5334-OUT;n:type:ShaderForge.SFN_Tex2d,id:2442,x:32130,y:32211,varname:node_2442,prsc:2,ntxv:0,isnm:False|TEX-5755-TEX;n:type:ShaderForge.SFN_TexCoord,id:3039,x:32231,y:33392,varname:node_3039,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4092,x:32517,y:32271,varname:node_4092,prsc:2|A-2442-RGB,B-6701-RGB;n:type:ShaderForge.SFN_Color,id:6701,x:32130,y:32368,ptovrint:False,ptlb:bg-color,ptin:_bgcolor,varname:node_6701,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_RemapRange,id:5478,x:32437,y:33392,varname:node_5478,prsc:2,frmn:0,frmx:1,tomn:-0.2,tomx:0.2|IN-3039-UVOUT;n:type:ShaderForge.SFN_Length,id:3967,x:32626,y:33392,varname:node_3967,prsc:2|IN-5478-OUT;n:type:ShaderForge.SFN_Add,id:4021,x:33133,y:32022,varname:node_4021,prsc:2|A-6348-OUT,B-3821-OUT;n:type:ShaderForge.SFN_Tex2d,id:5357,x:32517,y:31915,ptovrint:False,ptlb:logo,ptin:_logo,varname:node_5357,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4730-UVOUT;n:type:ShaderForge.SFN_Multiply,id:6348,x:32802,y:32264,varname:node_6348,prsc:2|A-5357-R,B-5357-A,C-1764-RGB,D-5259-OUT;n:type:ShaderForge.SFN_Color,id:1764,x:32517,y:32114,ptovrint:False,ptlb:logo-color,ptin:_logocolor,varname:node_1764,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_OneMinus,id:5,x:33040,y:33392,varname:node_5,prsc:2|IN-9828-OUT;n:type:ShaderForge.SFN_TexCoord,id:4730,x:32350,y:31936,varname:node_4730,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:4389,x:32130,y:32837,ptovrint:False,ptlb:mask-tex,ptin:_masktex,varname:node_4389,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5016-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5517,x:31700,y:32837,varname:node_5517,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:5755,x:31897,y:32548,ptovrint:False,ptlb:bg-tex,ptin:_bgtex,varname:node_5755,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1999,x:32130,y:32565,varname:node_1999,prsc:2,ntxv:0,isnm:False|TEX-5755-TEX;n:type:ShaderForge.SFN_Multiply,id:5656,x:32562,y:32646,varname:node_5656,prsc:2|A-1999-G,B-4854-OUT;n:type:ShaderForge.SFN_Multiply,id:9828,x:32828,y:33392,varname:node_9828,prsc:2|A-3967-OUT,B-2754-OUT;n:type:ShaderForge.SFN_Vector1,id:2754,x:32626,y:33535,varname:node_2754,prsc:2,v1:8;n:type:ShaderForge.SFN_Clamp,id:5259,x:33292,y:33392,varname:node_5259,prsc:2|IN-5-OUT,MIN-8805-OUT,MAX-5063-OUT;n:type:ShaderForge.SFN_Vector1,id:8805,x:33102,y:33521,varname:node_8805,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Vector1,id:5063,x:33102,y:33581,varname:node_5063,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:3821,x:32877,y:31938,varname:node_3821,prsc:2|A-4092-OUT,B-5656-OUT;n:type:ShaderForge.SFN_Panner,id:5016,x:31933,y:32837,varname:node_5016,prsc:2,spu:0,spv:1|UVIN-5517-UVOUT,DIST-9388-OUT;n:type:ShaderForge.SFN_Time,id:8155,x:31599,y:33013,varname:node_8155,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9388,x:31812,y:33028,varname:node_9388,prsc:2|A-8155-TSL,B-9901-OUT;n:type:ShaderForge.SFN_Slider,id:9901,x:31494,y:33172,ptovrint:False,ptlb:mask-speek,ptin:_maskspeek,varname:node_9901,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:20;n:type:ShaderForge.SFN_Multiply,id:7036,x:33157,y:32381,varname:node_7036,prsc:2|A-5357-A,B-5259-OUT;n:type:ShaderForge.SFN_Multiply,id:4854,x:32341,y:32709,varname:node_4854,prsc:2|A-6701-RGB,B-4389-R;n:type:ShaderForge.SFN_Add,id:5334,x:33364,y:32457,varname:node_5334,prsc:2|A-7036-OUT,B-8117-OUT;n:type:ShaderForge.SFN_Slider,id:2017,x:32918,y:32748,ptovrint:False,ptlb:mask_op,ptin:_mask_op,varname:node_2017,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:8117,x:33142,y:32567,varname:node_8117,prsc:2|A-4389-R,B-2017-OUT;proporder:5755-6701-5357-1764-4389-9901-2017;pass:END;sub:END;*/

Shader "Car/goal" {
    Properties {
        _bgtex ("bg-tex", 2D) = "white" {}
        [HDR]_bgcolor ("bg-color", Color) = (1,1,1,1)
        _logo ("logo", 2D) = "white" {}
        [HDR]_logocolor ("logo-color", Color) = (1,1,1,1)
        _masktex ("mask-tex", 2D) = "white" {}
        _maskspeek ("mask-speek", Range(0, 20)) = 5
        _mask_op ("mask_op", Range(0, 1)) = 0
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
            uniform float4 _bgcolor;
            uniform sampler2D _logo; uniform float4 _logo_ST;
            uniform float4 _logocolor;
            uniform sampler2D _masktex; uniform float4 _masktex_ST;
            uniform sampler2D _bgtex; uniform float4 _bgtex_ST;
            uniform float _maskspeek;
            uniform float _mask_op;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float4 _logo_var = tex2D(_logo,TRANSFORM_TEX(i.uv1, _logo));
                float node_5259 = clamp((1.0 - (length((i.uv0*0.4+-0.2))*8.0)),0.01,1.0);
                float4 node_2442 = tex2D(_bgtex,TRANSFORM_TEX(i.uv0, _bgtex));
                float4 node_1999 = tex2D(_bgtex,TRANSFORM_TEX(i.uv0, _bgtex));
                float4 node_8155 = _Time;
                float2 node_5016 = (i.uv0+(node_8155.r*_maskspeek)*float2(0,1));
                float4 _masktex_var = tex2D(_masktex,TRANSFORM_TEX(node_5016, _masktex));
                float3 finalColor = ((_logo_var.r*_logo_var.a*_logocolor.rgb*node_5259)+((node_2442.rgb*_bgcolor.rgb)+(node_1999.g*(_bgcolor.rgb*_masktex_var.r))));
                fixed4 finalRGBA = fixed4(finalColor,((_logo_var.a*node_5259)+(_masktex_var.r*_mask_op)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
