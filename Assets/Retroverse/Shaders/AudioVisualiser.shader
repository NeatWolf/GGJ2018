﻿Shader "Unlit/AudioVisualiser"
{
	Properties
	{
		_Multi ("Multiplier", Float) = 1
		_MainTex ("Texture", 2D) = "white" {}
		_BarCol ("Bar Colour", Color) = (1, 1, 1, 1)
		_BackCol ("Background Colour", Color) = (0, 0, 0, 1)

		_Timer ("Timer", Float) = 0
		_PlayWidth ("Playhead Width", float) = 0
		_PlayCol ("Playhead Color", Color) = (0.5, 0.5, 0.5, 1)
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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			fixed4 _MainTex_ST;

			half4 _BarCol;
			half4 _BackCol;
			half4 _PlayCol;
			
			float _Multi;
			float _Timer;
			float _PlayWidth;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				i.uv.y = saturate(i.uv.y);
				fixed4 col = tex2D(_MainTex, i.uv) * _Multi;
				float y = (i.uv.y * 2)-1;

				if (y < col.x && y > col.y) {
					col = _BarCol + fixed4(1, 1, 1, 1) * abs(y)*1.1;
				} else {
					col = _BackCol;	
				};

				if (i.uv.x > _Timer - _PlayWidth && i.uv.x < _Timer + _PlayWidth) {
					col = _PlayCol + fixed4(1, 1, 1, 1) * abs(y)*1.1;
				};
				return col;
			}
			ENDCG
		}
	}
}
