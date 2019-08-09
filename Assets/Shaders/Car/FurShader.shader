Shader "Fur/FurRimColorShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _LightPosition("LightPosition", Vector) = (0, 0, 0, 0)
        _Specular ("Specular", Color) = (1, 1, 1, 1)
        _Shininess ("Shininess", Range(0.01, 256.0)) = 8.0
        
        _MainTex ("Texture", 2D) = "white" { }
        _FurTex ("Fur Pattern", 2D) = "white" { }
        
        _FurLength ("Fur Length", Range(0.0, 1)) = 0.5
        _FurDensity ("Fur Density", Range(0, 2)) = 0.11
        _FurThinness ("Fur Thinness", Range(0.01, 10)) = 1
        _FurShading ("Fur Shading", Range(0.0, 1)) = 0.25

        _ForceGlobal ("Force Global", Vector) = (0, 0, 0, 0)
        _ForceLocal ("Force Local", Vector) = (0, 0, 0, 0)
        
        _RimColor ("Rim Color", Color) = (0, 0, 0, 1)
        _RimPower ("Rim Power", Range(0.0, 8.0)) = 6.0
    }
    
    Category
    {

        Tags { "RenderType" = "Transparent" "IgnoreProjector" = "True" "Queue" = "Transparent" }
        Cull Off
        LOD 200
        Fog { Mode Off }

        SubShader
        {
            Pass {
                ZWrite On
                ColorMask 0
            }

            Pass
            {
                ZWrite Off
                ZTest LEqual
                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal  
                #pragma target 3.0
                #pragma vertex vert_surface
                #pragma fragment frag_surface
                #define FURSTEP 0.00
                #include "FurHelper.cginc"
                
                ENDCG
                
            }

            /*
            Pass
            {
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.10
                #include "FurHelper.cginc"
                
                ENDCG
                
            }
            */
            
            Pass
            {
                ZWrite Off
                ZTest LEqual
                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.20
                #include "FurHelper.cginc"
                
                ENDCG
                
            }

            /*
            Pass
            {
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.30
                #include "FurHelper.cginc"
                
                ENDCG
                
            }*/

            
            Pass
            {
                ZWrite Off
                ZTest LEqual
                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.40
                #include "FurHelper.cginc"
                
                ENDCG
                
            }

            /*
            Pass
            {
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.50
                #include "FurHelper.cginc"
                
                ENDCG
                
            }
            */
            
            Pass
            {
                ZWrite Off
                ZTest LEqual
                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.60
                #include "FurHelper.cginc"
                
                ENDCG
                
            }

            /*
            Pass
            {
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.70
                #include "FurHelper.cginc"
                
                ENDCG
                
            }
            */
            
            Pass
            {
                ZWrite Off
                ZTest LEqual
                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.80
                #include "FurHelper.cginc"
                
                ENDCG
                
            }

            /*
            Pass
            {
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 0.90
                #include "FurHelper.cginc"
                
                ENDCG
                
            }
            */

            Pass
            {
                ZWrite Off
                ZTest LEqual
                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                #pragma only_renderers d3d9 d3d11 d3d11_9x glcore gles gles3 metal 
                #pragma target 3.0
                #pragma vertex vert_base
                #pragma fragment frag_base
                #define FURSTEP 1.00
                #include "FurHelper.cginc"
                
                ENDCG
                
            }
        }
        FallBack "Diffuse"
    }
}