    Shader "BRDF/Cook-Torrance" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
    }
        SubShader {
        Tags { "RenderType"="Opaque" }  //表面着色器 可以被若干的标签（tags）所修饰，而硬件将通过判定这些标签来决定什么时候调用该着色器。渲染非透明物体时调用我们
        LOD 100

        CGPROGRAM
        #pragma surface surf Standard  
        sampler2D _MainTex;
        float _Metallic;
        float _Glossiness;

        //surf 结构
        struct Input {float2 uv_MainTex;};
        void surf (Input IN, inout SurfaceOutputStandard o) {
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
        }

        ENDCG
    }
    FallBack "Standard"
    }