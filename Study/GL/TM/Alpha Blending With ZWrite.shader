Shader "Unity Shaders Book/Chapter 8/Alpha Blending With ZWrite" {
    Properties {
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Main Tex", 2D) = "white" {}
        _AlphaScale ("Alpha Scale", Range(0, 1)) = 1
    }
    SubShader {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        
        // �¼ӵ�Pass���
        Pass {
            ZWrite On
            ColorMask 0
        }
        
        Pass {
              //��ǰ��Ĵ�������һ��......
            }
            
            ENDCG
        }
    } 
    FallBack "Transparent/VertexLit"
}