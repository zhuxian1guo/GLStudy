Shader "Custom/WZY_Phong"
{
    Properties
    {
         // 漫反射颜色  高光颜色  gloss光着都
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

                //输入参数，注意与开头声明的对应
                uniform float3 Diffuse_Color;
                uniform float3 Specular_Color;
                uniform float   Specular_glossPow;
                uniform float3 Diffuse_Texture_Color;

                sampler2D _MainTex;
  

                //输入结构
                struct Input
                {
                        float4 vertex : POSITION; //顶点
                        float3 normal : NORMAL; //法线
                };

                //输出结构
                struct Output
                {
                    float4 posCS : SV_POSITION; //裁剪空间下的坐标
                    float4 posWS : TEXCOORD0; //世界空间下的坐标
                    float3 nDirWS : TEXCOORD1; //法线向量
                };

                 //顶点shader ??
                 Output vert (Input v) {
                        Output o = (Output)0;
                        o.posCS = UnityObjectToClipPos(v.vertex);             //顶点转换到裁剪空间
                        o.posWS = mul(unity_ObjectToWorld, v.vertex);     //顶点位置位置转化到世界空间
                        o.nDirWS = UnityObjectToWorldNormal(v.normal);   //法线转换到世界空间
                        return o;
                    }

                //像素shader
                float4 frag(Output i) : COLOR {
                    //准备向量
                    float3 nDir = i.nDirWS; //法线向量
                    float3 lDir = _WorldSpaceLightPos0.xyz; //光照方向
                    float3 vDir = normalize(_WorldSpaceCameraPos.xyz - i.posWS); //视角方向，用相机位置-顶点位置就是视角方向
                    float3 rDir = normalize(reflect(-lDir, nDir)); //反射方向，使用reflect函数实现，注意由于该函数要求光入射方向要指向交点处，因此对lDir先取反
                    //准备点积结果
                    float ndotl = dot(nDir, lDir);
                    float rdotv = dot(rDir, vDir);
                    //光照模型计算
                    float3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb; //环境光
                    float3 diffuse = _LightColor0.rgb * Diffuse_Color * max(0, ndotl); //漫反射
                    float3 specular = _LightColor0.rgb * Specular_Color * pow(max(0, rdotv), Specular_glossPow); //高光
                    float3 phong =  ambient + diffuse + specular; //最终颜色
                    return float4(phong, 1.0);
                }

                //片元shader
                //struct Input1{float2 uv_MainTex;};
                //void surf(Input1 X,inout SurfaceOutput o){
                //        o.Albedo =tex2D(_MainTex, X.uv_MainTex).rgb;
                //}         
                 ENDCG
            }       
    }
    FallBack "Diffuse"
}
