
Shader "FXLab/Particles/Add Blended" {
	Properties {
		_FXDepthTexture ("Depth Texture (FXDepthTexture)", 2D) = "" {}
		_Color ("Tint Color", Color) = (1, 1, 1, 0.5)
		_MainTex ("Main Texture", 2D) = "white" {}
		_Softness ("Softness", Float) = 1
	}
	SubShader {
		Blend One One
		
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		Lighting Off
		Cull Off
		Fog { Mode Off }
		ZWrite Off
		
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#include "UnityCG.cginc"
			#include "../FXLab.cginc"
			
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Softness;
			fixed4 _Color;
			
			struct appdata {
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
				float4 color : COLOR0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 screenPos : TEXCOORD2;
				float depth : TEXCOORD3;
				float4 color : COLOR0;
			};
			
			v2f vert (appdata v) {
				v2f o;
				o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
				o.uv = TRANSFORM_TEX(v.texcoord.xy, _MainTex);
				o.screenPos = o.pos;
				o.color = v.color;
				o.depth = o.pos.z;
				return o;
			}
			
			float4 frag( v2f o ) : COLOR
			{
				float2 screenUv = calcScreenUv(o.screenPos);
				
				fixed4 color = tex2D(_MainTex, o.uv) * o.color * _Color;
				float depth = sampleDepth(screenUv);
				
				float d = o.depth;
				color *= min(1, abs(d - depth) / _Softness);
				return color;
			}
			ENDCG
		}
	}
	Fallback off
	CustomEditor "FXMaterialEditor"
}
