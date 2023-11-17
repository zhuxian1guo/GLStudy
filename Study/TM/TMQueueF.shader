Shader "MyShader/Chapter 8/Alpha Test-TransparentCutout" {
    Properties {
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Main Tex", 2D) = "white" {}
        //_Cutoff 参数用于决定我们调用 clip 进行透明度测试时使用的判断条件，它的范围是[O, 1],这是因为纹理像素的透明度就是在此范围内。
        _Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5 
    }
    SubShader {
        //把Queue标签设置为AlphaTest    
        //把IgnoreProjector设置为true，意味着这个Shader不会受到投影器(Properties)的影响
        //RenderType标签可以让Unity把这个Shader归入到提前定义的组(TransparentCutout组)，以指明该Shader是一个使用了透明度测试的Shader
        //使用了透明度测试的Shader都应该在SubShader设置三个标签
        Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
        
        Pass {
            //LightMode用于定义该Pass在Unity的光照流水线中的角色。只有正确定义LightMode，才能正确得到一些Unity的内置光照，如_LightColor0
            Tags { "LightMode"="ForwardBase" }
            
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Lighting.cginc"
            
            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Cutoff;//由于_Cutoff 范围在[O I], 因此我们可以使用 fixed精度来存储它。
            
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
                
                // 透明测试
                clip (texColor.a - _Cutoff);//如果texColor.a - _Cutoff为负数，就舍弃改片元的输出。
                // 相当于下面的代码
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
    FallBack "Transparent/Cutout/VertexLit"//设置回调，这个回调在后面第九章节会讲
}