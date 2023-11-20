 Shader "Example/Rim" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0) // ��Ե�����ɫ
      _Detail ("Detail", 2D) = "gray" {} // ϸ������[4]
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0 // ��Ե���ǿ��
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 viewDir;   // �۲�����
          float2 uv_Detail;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      float4 _RimColor;
      float _RimPower;
      sampler2D _Detail;

      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
              // �������ϸ���������
          o.Albedo *= tex2D (_Detail, IN.uv_Detail).rgb * 2;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
          // �Թ۲������ͷ��������������ֵԽС����������������н�Խ�ӽ�90�ȣ���Ϊ������Ե
          half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal)); 
          // Խ�ӽ���Ե�������Ĺ�Խ��
          o.Emission = _RimColor.rgb * pow (rim, _RimPower);
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }