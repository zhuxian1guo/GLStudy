Shader "Example/Diffuse Bump" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {} // 法向贴图[3]
      _Detail ("Detail", 2D) = "gray" {} // 细节纹理[4]
    }
    SubShader {
      Tags { "RenderType" = "Opaque" } 
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
        float2 uv_MainTex;
        float2 uv_BumpMap;
        float2 uv_Detail;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
       sampler2D _Detail;
      void surf (Input IN, inout SurfaceOutput o) {
        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
              // 将纹理和细节纹理叠加
        o.Albedo *=  tex2D (_Detail, IN.uv_Detail).rgb * 2;
        o.Normal =   UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap)); // 将从法向贴图中取得的法向量赋给output
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }