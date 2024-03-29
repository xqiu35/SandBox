// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Merlin/5.2.2f1/Hidden/Internal-Halo" { 
	Properties {[HideInInspector] _StencilRefValue ("StencilRefValue", Int) = 187 }
	SubShader {Stencil{Ref [_StencilRefValue] Comp always Pass replace ZFail replace }
		Tags {"RenderType"="Overlay"}
		ZWrite off Cull off	// NOTE: 'Cull off' is important as the halo meshes flip handedness each time... BUG: #1220
		Blend OneMinusDstColor One
		ColorMask RGB
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			sampler2D _HaloFalloff;
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};
			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_FOG_COORDS(1)
			};
			float4 _HaloFalloff_ST;
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_HaloFalloff);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			fixed4 frag (v2f i) : SV_Target
			{
				fixed a = tex2D(_HaloFalloff, i.texcoord).a;
				fixed4 col = fixed4 (i.color.rgb * a, a);
				UNITY_APPLY_FOG_COLOR(i.fogCoord, col, fixed4(0,0,0,0)); // fog towards black due to our blend mode
				return col;
			}
			ENDCG  
		}  
	}
}
