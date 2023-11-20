Shader "BRDF/GGX"
{
    Properties
    {
        _Kdiff ("Kdiff", float) = 0.1
		_Kspec ("Kspec", float) = 0.4
		_Alpha ("Alpha", float) = 0.05
		_F0 ("F0", float) = 0.8
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Lighting.cginc"

			#define PI 3.1415926535

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float3 posW : TEXCOORD0;
				float3 normW : TEXCOORD1;
            };

            float _Kdiff;
			float _Kspec;
			float _Alpha;
			float _F0;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.posW = mul(unity_ObjectToWorld, v.vertex);
				o.normW = mul(v.normal, (float3x3)unity_WorldToObject);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float3 V = normalize(_WorldSpaceCameraPos - i.posW);
				float3 L = normalize(_WorldSpaceLightPos0.xyz);
				float3 H = normalize(L + V);
				float3 N = normalize(i.normW);

				float NdotH = dot(N, H);
				float NdotL = dot(N, L);
				float NdotV = dot(N, V);
				float HdotV = dot(H, V);

				float alpha2 = _Alpha * _Alpha;
				float tanNL2 = 1 / (NdotL * NdotL + 1e-8) - 1;
				float tanNV2 = 1 / (NdotV * NdotV + 1e-8) - 1;

				float F = _F0 + (1 - _F0) * pow(1 - HdotV, 5);
				float D = alpha2 / (PI * pow(NdotH * NdotH * (alpha2 - 1) + 1, 2));
				float G = 4 / ((1 + sqrt(1 + alpha2 * tanNL2)) * (1 + sqrt(1 + alpha2 * tanNV2)));
				float fr = _Kdiff / PI +
						   _Kspec * F * D * G / (4 * NdotL * NdotV);

                return fixed4(max(0, fr) * _LightColor0.rgb * max(0, NdotL), 1.0f);
            }
            ENDCG
        }
    }
}
