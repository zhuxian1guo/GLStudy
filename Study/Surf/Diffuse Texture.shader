  Shader "Example/Diffuse Texture" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {} // 纹理，若没有赋值则默认为全白
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex; // 纹理uv坐标
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb; // 按uv坐标查找纹理上的像素，并获取rgb值
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }