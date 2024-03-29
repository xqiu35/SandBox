﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Merlin/5.2.2f1/Hidden/GIDebug/VertexColors" {
	Properties {[HideInInspector] _StencilRefValue ("StencilRefValue", Int) = 187
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {Stencil{Ref [_StencilRefValue] Comp always Pass replace ZFail replace }
		Pass {
			Tags { "RenderType"="Opaque" }
			LOD 200

			CGPROGRAM
			#pragma vertex vert_surf
			#pragma fragment frag_surf
			#include "UnityCG.cginc"

			struct v2f_surf
			{
				float4 pos		: SV_POSITION;
				fixed4 color	: COLOR;
			};

			v2f_surf vert_surf (appdata_full v)
			{
				v2f_surf o;
				o.pos = UnityObjectToClipPos (v.vertex);
				o.color = v.color;
				return o;
			}

			float4 frag_surf (v2f_surf IN) : COLOR
			{
				return IN.color;
			}
			ENDCG
		}
	}
}
