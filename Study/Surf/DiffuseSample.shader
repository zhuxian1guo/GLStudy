 Shader "Example/Diffuse Simple" {
    SubShader {
      Tags { "RenderType" = "Opaque" } // ��ǩ������ʲôʱ����Ⱦ���Բ�͸��������Ⱦ��
      CGPROGRAM // //CG���Ա�ǿ�ʼ
      #pragma surface surf Lambert // ����ָ�� surface shader �Զ��庯�� ����ģ��[1] 
      struct Input {               // ����Ľṹ��
          float4 color : COLOR;    // ��ɫֵ
      };
      void surf (Input IN, inout SurfaceOutput o) { // surface shader������
          o.Albedo = 1;  // ��������ɫ��Ϊ��ɫ[2]
      }
      ENDCG
    }
    Fallback "Diffuse" // �����쳣ʱ�ع���Unity���õ�Diffuse shader
  }