Shader "Custom/Stage/Sky" {
	Properties {
		_SideTex ("Side Tex"     , 2D    ) = "white" {}
		_TopTex  ("Top Tex"      , 2D    ) = "black" {}
		_SunTex  ("Sun Tex"      , 2D    ) = "black" {}
		_Gamma   ("Gamma"        , Float) = 1.0
		_SkyInt  ("Sky Intensity", Float) = 1.0
		_SunInt  ("Sun Intensity", Float) = 1.0
		_SunPos  ("Sun Position" , Float) = 0.0
	}

	SubShader {
		Tags {
			"Queue"      = "Geometry"
			"RenderType" = "Opaque"
		}

		Pass {
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				sampler2D _SideTex;
				sampler2D _TopTex;
				sampler2D _SunTex;
				half _Gamma;
				half _SkyInt;
				half _SunInt;
				half _SunPos;

				struct appdata {
					float4 vertex : POSITION;
					float2 uv1    : TEXCOORD0;
					float2 uv2    : TEXCOORD1;
				};

				struct v2f {
					float4 vertex : SV_POSITION;
					float2 uv1    : TEXCOORD0;
					float2 uv2    : TEXCOORD1;
				};
				
				v2f vert (appdata v) {
					v2f o;

					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv1    = v.uv1.xy;
					o.uv2    = v.uv2.xy;

					return o;
				}
				
				fixed4 frag (v2f i) : SV_Target {
					fixed3 sideTex = tex2D(_SideTex, i.uv1).rgb;
					fixed4 topTex  = tex2D(_TopTex, i.uv2);
					fixed2 sunTex  = tex2D(_SunTex, i.uv1 + float2(_SunPos, 0)).rg;

					fixed3 final = lerp(sideTex, topTex.rgb, topTex.a);
					final = pow(final, _Gamma);
					final += ((sunTex.r * min(_SunInt, 1)) * lerp(1, _SunInt, sunTex.r));
					final *= _SkyInt;

					return fixed4(clamp(final, 0, 0.95), 1);
				}
			ENDCG
		}
	}
}