Shader "Unlit/Specular_Vert"
{
    Properties
    {
       _Diffuse ("Diffuse",Color) = (1,1,1,1)  //��������ɫ
       _Specular ("Specular",Color) = (1,1,1,1)  //�߹ⷴ����ɫ
       _Gloss ("Gloss",Range(8.0,256)) = 20  //�߹������С
    }
    SubShader
    {
        /*��LightMode�� ��Pass��ǩ��һ�֣������ڶ����Passͨ����Unity�Ĺ�����ˮ���еĽ�ɫ��
        ֻ�ж�������ȷ��LightMode,���ܵõ�һЩUnity�����ù��ձ���*/
        Tags { "LightMode"="ForwardBase" }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                fixed3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed3 color : COLOR;
            };

            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;
            v2f vert (appdata v)
            {
                v2f o;
                //ģ�Ϳռ䶥��ת�����ü��ռ�
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                //��ȡ��������ɫ
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                
                //��ȡ��һ������ռ䷨��
                fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));

                //��ȡ��һ������ռ���շ���
                fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);

                //ʹ��������ģ�ͼ������������
                fixed3 diffuse = _Diffuse.rgb * _LightColor0.rgb * saturate(dot(worldNormal,worldLightDir));

                //��ȡ��һ������ռ��ӽǷ���
                //fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld,v.vertex).xyz);
                fixed3 viewDir = normalize(WorldSpaceViewDir(v.vertex));

                //��ȡ��һ������ⷽ��(����ͼ��ѧ�й�Դ������ָ���Դ�ģ���reflect���������䷽��Ҫ���Դ��ָ�򽻵㴦�ģ�����Ҫ��worldLightDirȡ��)
                fixed3 reflectDir = normalize(reflect(-worldLightDir,worldNormal));
                
                //ʹ��Phongģ�ͼ���߹ⷴ��
                fixed3 specular =  _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(reflectDir,viewDir)),_Gloss);
                
                o.color = ambient + diffuse + specular;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return fixed4(i.color,1);
            }
            ENDCG
        }
    }
    FallBack "Specular"
}