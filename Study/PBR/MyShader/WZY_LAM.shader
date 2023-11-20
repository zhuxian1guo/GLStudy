Shader "WZY/Lambertian"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "LightMode"="ForwardBase"} 
        LOD 100

       CGPROGRAM      
            #pragma surface surf  Lambert
            sampler2D _MainTex;
            struct Input{float2 uv_MainTex;};
            void surf(Input X,inout SurfaceOutput o){
                    o.Albedo =tex2D(_MainTex, X.uv_MainTex).rgb;
            }           
         ENDCG
    }
    FallBack "Diffuse"
}
