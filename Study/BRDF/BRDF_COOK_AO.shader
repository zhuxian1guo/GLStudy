Shader "BRDF/Cook-Torrance-AO" {
Properties {
_MainTex ("Texture", 2D) = "white" {}
_Metallic ("Metallic", Range(0,1)) = 0
_Glossiness("Smoothness", Range(0,1))= 0.5
_Occlusion ("Occlusion", 2D) = "white" {}
}
SubShader {
Tags { "RenderType"="Opaque"}
LOD 100
    CGPROGRAM
     #pragma surface surf Standard
     sampler2D _MainTex;
     sampler2D _Occlusion;
     float _Metallic;
     float _Glossiness;
     struct Input {
     float2 uv_MainTex;
     float2 uv_Occlusion;
     };
     void surf (Input IN, inout SurfaceOutputStandard o) {
     o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
     o.Metallic = _Metallic;
     o.Smoothness = _Glossiness;
     o.Occlusion = tex2D (_Occlusion, IN.uv_Occlusion).r;}
     ENDCG
}
FallBack "Standard"
}