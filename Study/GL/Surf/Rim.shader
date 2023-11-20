 Shader "Example/Rim" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0) // 边缘光的颜色
      _Detail ("Detail", 2D) = "gray" {} // 细节纹理[4]
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0 // 边缘光的强度
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 viewDir;   // 观察向量
          float2 uv_Detail;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      float4 _RimColor;
      float _RimPower;
      sampler2D _Detail;

      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
              // 将纹理和细节纹理叠加
          o.Albedo *= tex2D (_Detail, IN.uv_Detail).rgb * 2;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
          // 对观察向量和法向量求点积，这个值越小，代表这两个方向夹角越接近90度，即为轮廓边缘
          half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal)); 
          // 越接近边缘，发出的光越亮
          o.Emission = _RimColor.rgb * pow (rim, _RimPower);
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }