Shader "Custom/WrapLambert" 
{
 Properties 
 {
  _MainTex ("Texture", 2D) = "white" {}
  _BumpMap ("Bumpmap", 2D) = "Bump" {}
  _WrapMultiplier ("WrapMulitplier", Range(0,10)) = 0.5
  _WrapAdditive ("WrapAdditive", Range(0,10)) = 0.5
 }
 SubShader 
 {
  Tags { "RenderType"="Opaque" }
  LOD 200
  
  CGPROGRAM
  #pragma surface surf WrapLambert
  
  float _WrapMultiplier;
  float _WrapAdditive;
  
  half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten)
  {
   half NdotL = dot (s.Normal, lightDir);
   half diff = NdotL * _WrapMultiplier + _WrapAdditive;
   half4 c;
   c.rgb = s.Albedo * _LightColor0.rgb  * (diff * atten * 2);
   c.a = s.Alpha;
   return c;
  }

  struct Input 
  {
   float2 uv_MainTex;
   float2 uv_BumpMap;
  };
  
  sampler2D _MainTex;
  sampler2D _BumpMap;

  void surf (Input IN, inout SurfaceOutput o) 
  {
   o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
   o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
  }
  ENDCG
 } 
 FallBack "Diffuse"
}
