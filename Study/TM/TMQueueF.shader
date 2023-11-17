Shader "MyShader/Chapter 8/Alpha Test-TransparentCutout" {
    Properties {
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Main Tex", 2D) = "white" {}
        //_Cutoff �������ھ������ǵ��� clip ����͸���Ȳ���ʱʹ�õ��ж����������ķ�Χ��[O, 1],������Ϊ�������ص�͸���Ⱦ����ڴ˷�Χ�ڡ�
        _Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5 
    }
    SubShader {
        //��Queue��ǩ����ΪAlphaTest    
        //��IgnoreProjector����Ϊtrue����ζ�����Shader�����ܵ�ͶӰ��(Properties)��Ӱ��
        //RenderType��ǩ������Unity�����Shader���뵽��ǰ�������(TransparentCutout��)����ָ����Shader��һ��ʹ����͸���Ȳ��Ե�Shader
        //ʹ����͸���Ȳ��Ե�Shader��Ӧ����SubShader����������ǩ
        Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
        
        Pass {
            //LightMode���ڶ����Pass��Unity�Ĺ�����ˮ���еĽ�ɫ��ֻ����ȷ����LightMode��������ȷ�õ�һЩUnity�����ù��գ���_LightColor0
            Tags { "LightMode"="ForwardBase" }
            
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Lighting.cginc"
            
            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Cutoff;//����_Cutoff ��Χ��[O I], ������ǿ���ʹ�� fixed�������洢����
            
            struct a2v {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };
            
            struct v2f {
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float2 uv : TEXCOORD2;
            };
            
            v2f vert(a2v v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target {
                fixed3 worldNormal = normalize(i.worldNormal);
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
                
                fixed4 texColor = tex2D(_MainTex, i.uv);
                
                // ͸������
                clip (texColor.a - _Cutoff);//���texColor.a - _CutoffΪ��������������ƬԪ�������
                // �൱������Ĵ���
                //if ((texColor.a - _Cutoff) < 0.0) {
                //    discard;
                //}
                
                fixed3 albedo = texColor.rgb * _Color.rgb;
                
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));
                
                return fixed4(ambient + diffuse, 1.0);
            }
            
            ENDCG
        }
    } 
    FallBack "Transparent/Cutout/VertexLit"//���ûص�������ص��ں���ھ��½ڻὲ
}