Shader "Micro_Macro/Background"
{
	Properties
	{
		_SideTex("Side Tex"     , 2D) = "white" {}
		_TopTex("Top Tex"      , 2D) = "black" {}
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
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv1: TEXCOORD1;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float uv1 : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _SideTex;
			sampler2D _TopTex;
			float4 _SideTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv.xy;
				o.uv1 = v.uv1.xy;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 sideTex = tex2D(_SideTex, i.uv);
				fixed4 topTex = tex2D(_TopTex, i.uv1);
				fixed3 col = lerp(sideTex.rgb, topTex.rgb, topTex.a);
				return fixed4(col, 1);
			}
			ENDCG
		}
	}
}
