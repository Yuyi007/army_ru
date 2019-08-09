// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Car2D/HengFlipping"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Hor ("Is Horizontal Filp", Range (0, 1)) = 0
        _Ver ("Is Vertical Filp", Range (0, 1)) = 0
	}
	SubShader
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
         
        Pass 
        {
            Tags { "LightMode"="ForwardBase" }
            ZTest off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
             
            CGPROGRAM
            #pragma vertex vert  
            #pragma fragment frag
            #include "UnityCG.cginc"
         
            sampler2D _MainTex;
            int _Hor;
            int _Ver;
               
            struct a2v 
            {  
                float4 vertex : POSITION; 
                float2 texcoord : TEXCOORD0;
            };  
             
            struct v2f 
            {  
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };  
             
            v2f vert (a2v v) 
            {  
                v2f o;  
                o.pos = UnityObjectToClipPos(v.vertex);  
                 
                o.uv.x = (1-v.texcoord.x)*_Hor + v.texcoord.x*(1-_Hor);
                o.uv.y = (1-v.texcoord.y)*_Ver + v.texcoord.y*(1-_Ver);
                return o;
            }  
             
            fixed4 frag (v2f i) : SV_Target 
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                return c;
            }
            ENDCG
		}
	}
}
