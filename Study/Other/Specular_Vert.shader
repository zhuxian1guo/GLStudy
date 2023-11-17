Shader "Unlit/Specular_Vert"
{
    Properties
    {
       _Diffuse ("Diffuse",Color) = (1,1,1,1)  //漫反射颜色
       _Specular ("Specular",Color) = (1,1,1,1)  //高光反射言色
       _Gloss ("Gloss",Range(8.0,256)) = 20  //高光区域大小
    }
    SubShader
    {
        /*“LightMode” 是Pass标签的一种，它用于定义该Pass通道在Unity的光照流水线中的角色，
        只有定义了正确的LightMode,才能得到一些Unity的内置光照变量*/
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
                //模型空间顶点转换到裁剪空间
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                //获取环境光颜色
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                
                //获取归一化世界空间法线
                fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));

                //获取归一化世界空间光照方向
                fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);

                //使用兰伯特模型计算漫反射光照
                fixed3 diffuse = _Diffuse.rgb * _LightColor0.rgb * saturate(dot(worldNormal,worldLightDir));

                //获取归一化世界空间视角方向
                //fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld,v.vertex).xyz);
                fixed3 viewDir = normalize(WorldSpaceViewDir(v.vertex));

                //获取归一化反射光方向(由于图形学中光源方向是指向光源的，而reflect函数的入射方向要求光源是指向交点处的，则需要对worldLightDir取反)
                fixed3 reflectDir = normalize(reflect(-worldLightDir,worldNormal));
                
                //使用Phong模型计算高光反射
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