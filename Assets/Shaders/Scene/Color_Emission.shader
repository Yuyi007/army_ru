// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'


Shader "Scene/ColorEmission"
{
    Properties
    {
        [Header(version_3)]
        [HDR]_Color("Color", Color) = (2,2,2,1)
    }

    SubShader
    {
        Tags{  "LightMode"="ForwardBase" "RenderType" = "Opaque" "Queue" = "Geometry" }
        LOD 200
        Fog { Mode Off }
        Lighting On
        ZWrite On
        Cull Back
        Pass {

            

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0

            #include "UnityCG.cginc"

            uniform float4 _Color;


            struct a2v
            {
                fixed4 vertex   : POSITION;
            };

            struct v2f
            {
                fixed4 pos          : SV_POSITION;
            };


            v2f vert(a2v v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            float4 frag(v2f i) : COLOR
            {
                return _Color;
            }

            ENDCG
        }

    }
    FallBack "Diffuse"
}