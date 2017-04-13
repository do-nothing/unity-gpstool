// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Microwise/Map" {
	Properties {
		_MainTex ("Main Tex", 2D) = "white" {}
	}
	SubShader {		
		Pass { 
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			struct a2v {
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD2;
			};
			
			v2f vert(a2v v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				float2 tiling = float2(_MainTex_ST.x*_MainTex_ST.y,_MainTex_ST.x);
				o.uv = v.texcoord.xy * tiling + (float2(1,1)-tiling)/2 + _MainTex_ST.zw;
				
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				
				// Use the texture to sample the diffuse color
				fixed3 bgColor = tex2D(_MainTex, i.uv).rgb;
				
				return fixed4(bgColor, 1.0);
			}
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
