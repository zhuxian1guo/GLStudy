    Shader "BRDF/Cook-Torrance" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
    }
        SubShader {
        Tags { "RenderType"="Opaque" }  //������ɫ�� ���Ա����ɵı�ǩ��tags�������Σ���Ӳ����ͨ���ж���Щ��ǩ������ʲôʱ����ø���ɫ������Ⱦ��͸������ʱ��������
        LOD 100

        CGPROGRAM
        #pragma surface surf Standard  
        sampler2D _MainTex;
        float _Metallic;
        float _Glossiness;

        //surf �ṹ
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