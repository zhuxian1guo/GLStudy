Shader "Custom/Test1"
{
    Properties
    {
        //���ڿ��������������ɫ����
        _Color("Color",Color)=(1,1,1,1)
        _MainTex("��������",2D)="white"{}
        _Specular("Specular",Color)=(1,1,1,1)
        _Gloss("Gloss",Range(0,256))=20
        
        _AlphaTest("͸���Ȳ�����ֵ",float)=0.5
        
    }
    SubShader
    {
        
        Pass
        {
            Tags{"LightMode"="ForwardBase"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"
            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Specular;
            fixed _Gloss;
            fixed _AlphaTest;
            struct a2v
            {
                float4 vertex:POSITION;
                float3 normal:NORMAL;
                float4 texcoord:TEXCOORD0;
            };
 
            struct v2f
            {
                float4 pos:SV_POSITION;
                float3 worldNormal :TEXCOORD0;                
                float3 worldPos:TEXCOORD1;
                float2 uv:TEXCOORD3;                       
            };
            
            v2f vert(a2v v)
            {
                v2f o;
                o.pos=UnityObjectToClipPos(v.vertex);
               
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
 
                o.worldPos=mul(unity_ObjectToWorld,v.vertex);
              
                o.uv=TRANSFORM_TEX(v.texcoord,_MainTex);
                
                return o;
                
            }
 
            fixed4 frag(v2f i):SV_Target
            {                
                fixed3 ambient=UNITY_LIGHTMODEL_AMBIENT.rgb;
                
                fixed3 worldNormal=normalize(i.worldNormal);
                
                fixed3 worldLight=normalize(_WorldSpaceLightPos0.xyz);
                
                //�������
                fixed4 texResult=tex2D(_MainTex,i.uv)*_Color;
 
                //͸���Ȳ��ԣ������������Ϊ����
                clip(texResult.a-_AlphaTest);
                
                fixed3 diffuse=_LightColor0*texResult
                            *(0.5*dot(worldLight,worldNormal)+0.5);
                
                fixed3 viewDir=normalize(_WorldSpaceCameraPos-i.worldPos);
                
                fixed3 halfDir=normalize(viewDir+worldLight);
                
                fixed3 specular=_LightColor0.rgb*_Specular
                            *pow(saturate(dot(worldNormal,halfDir)),_Gloss);
                
                return fixed4(ambient+diffuse+specular,1);
            }
            
            ENDCG
        }
    }
}