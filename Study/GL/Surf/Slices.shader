Shader "Example/Slices" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      Cull Off
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 worldPos;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      void surf (Input IN, inout SurfaceOutput o) {
       //  �Զ������Ƭ��������y��z��Ϊ��������ζ��x������Ƭ��
       //  frac��������ѧ�г�����һ�ֺ���,�����Խ�һ��������ʾΪ���������ı�ֵ��
       //   frac�������ر�����ÿ��ʸ���и�������С�����֡�
          clip (frac((IN.worldPos.y+IN.worldPos.z*0.1) * 5) - 0.5);       
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }