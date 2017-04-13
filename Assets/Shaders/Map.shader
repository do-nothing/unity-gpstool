Shader "Microwise/Map" {
	Properties {
		_BgTex ("Bg Tex", 2D) = "white" {}
		_MapTex ("Map Tex", 2D) = "white" {}
		_PlayerTex ("Player Tex", 2D) = "white" {}
		_Target ("Target", Vector) = (0, 0, 1, 1)
	}
	SubShader {		
		Pass { 
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			
			sampler2D _BgTex;
			float4 _BgTex_ST;
			sampler2D _MapTex;
			sampler2D _PlayerTex;
			float4 _PlayerTex_ST;
			float4 _Target;
			
			struct a2v {
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD1;
				float2 uv2: TEXCOORD2;
			};
			
			v2f vert(a2v v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				float2 tiling = float2(_BgTex_ST.x*_BgTex_ST.y,_BgTex_ST.x);
				o.uv = v.texcoord.xy * tiling + (float2(1,1)-tiling)/2 + _BgTex_ST.zw;
				o.uv2 = v.texcoord.xy * _PlayerTex_ST.xy + _PlayerTex_ST.zw;

				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				i.uv += 0.5;
				fixed3 color;
				if (i.uv.x > 2 || i.uv.x < 0 || i.uv.y < 0 || i.uv.y > 2){
					color = tex2D(_BgTex, i.uv).rgb;	
				} else {
					i.uv *= 0.5;
					color = tex2D(_MapTex, i.uv).rgb;	
					_Target /= 100;
					if(distance(i.uv, _Target.xy) < _Target.z){
						color = lerp(color, float4(0,0.5,1,1), 0.2);
					}
				}

				

				fixed4 playerColor = tex2D(_PlayerTex, i.uv2);
				color = lerp(color, playerColor.rgb, playerColor.w);
				return fixed4(color, 1.0);
			}
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
