  Shader "Example/Diffuse Texture" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {} // ������û�и�ֵ��Ĭ��Ϊȫ��
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex; // ����uv����
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb; // ��uv������������ϵ����أ�����ȡrgbֵ
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }