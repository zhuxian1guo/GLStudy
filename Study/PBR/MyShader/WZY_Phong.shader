Shader "Custom/WZY_Phong"
{
    Properties
    {
         // ��������ɫ  �߹���ɫ  gloss���Ŷ�
          Diffuse_Color ("DiffuseCol", Color) = (1,1,1,1)
          Specular_Color ("SpecCol", Color) = (1,1,1,1)
          Specular_glossPow("Specular_glossPow",Range(1,90))=30
          Diffuse_Texture_Color ("DiffuseCol", Color) = (1,1,1,1)
          _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200



         Pass {
                    Name "FORWARD"
                    Tags {
                        "LightMode"="ForwardBase"
                    }
                
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                //#pragma surface surf Standard
                #include "Lighting.cginc"

                //���������ע���뿪ͷ�����Ķ�Ӧ
                uniform float3 Diffuse_Color;
                uniform float3 Specular_Color;
                uniform float   Specular_glossPow;
                uniform float3 Diffuse_Texture_Color;

                sampler2D _MainTex;
  

                //����ṹ
                struct Input
                {
                        float4 vertex : POSITION; //����
                        float3 normal : NORMAL; //����
                };

                //����ṹ
                struct Output
                {
                    float4 posCS : SV_POSITION; //�ü��ռ��µ�����
                    float4 posWS : TEXCOORD0; //����ռ��µ�����
                    float3 nDirWS : TEXCOORD1; //��������
                };

                 //����shader ??
                 Output vert (Input v) {
                        Output o = (Output)0;
                        o.posCS = UnityObjectToClipPos(v.vertex);             //����ת�����ü��ռ�
                        o.posWS = mul(unity_ObjectToWorld, v.vertex);     //����λ��λ��ת��������ռ�
                        o.nDirWS = UnityObjectToWorldNormal(v.normal);   //����ת��������ռ�
                        return o;
                    }

                //����shader
                float4 frag(Output i) : COLOR {
                    //׼������
                    float3 nDir = i.nDirWS; //��������
                    float3 lDir = _WorldSpaceLightPos0.xyz; //���շ���
                    float3 vDir = normalize(_WorldSpaceCameraPos.xyz - i.posWS); //�ӽǷ��������λ��-����λ�þ����ӽǷ���
                    float3 rDir = normalize(reflect(-lDir, nDir)); //���䷽��ʹ��reflect����ʵ�֣�ע�����ڸú���Ҫ������䷽��Ҫָ�򽻵㴦����˶�lDir��ȡ��
                    //׼��������
                    float ndotl = dot(nDir, lDir);
                    float rdotv = dot(rDir, vDir);
                    //����ģ�ͼ���
                    float3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb; //������
                    float3 diffuse = _LightColor0.rgb * Diffuse_Color * max(0, ndotl); //������
                    float3 specular = _LightColor0.rgb * Specular_Color * pow(max(0, rdotv), Specular_glossPow); //�߹�
                    float3 phong =  ambient + diffuse + specular; //������ɫ
                    return float4(phong, 1.0);
                }

                //ƬԪshader
                //struct Input1{float2 uv_MainTex;};
                //void surf(Input1 X,inout SurfaceOutput o){
                //        o.Albedo =tex2D(_MainTex, X.uv_MainTex).rgb;
                //}         
                 ENDCG
            }       
    }
    FallBack "Diffuse"
}
