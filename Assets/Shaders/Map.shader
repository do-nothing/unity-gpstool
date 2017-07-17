Shader "Microwise/Map" {
	Properties {
		_BgTex ("Bg Tex", 2D) = "white" {}
		_MainTex ("Map Tex", 2D) = "white" {}
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
			sampler2D _MainTex;
			sampler2D _PlayerTex;
			sampler2D _triggers;
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
				o.uv = v.texcoord.xy * tiling + (float2(1,1)-tiling) * 0.5 + _BgTex_ST.zw;

				//move player
				float2 _PlayerTex_ST_zw = (_BgTex_ST.zw -_Target.xy / 30) * _PlayerTex_ST.y / _BgTex_ST.x;
				_PlayerTex_ST_zw.x += (2 / (_BgTex_ST.x * _BgTex_ST.y) - 1) * 0.5 * _PlayerTex_ST.x;
				_PlayerTex_ST_zw.y += (2 / _BgTex_ST.x  - 1) * 0.5 * _PlayerTex_ST.y;
				_PlayerTex_ST_zw += _PlayerTex_ST.zw;
				o.uv2 = v.texcoord.xy * _PlayerTex_ST.xy + _PlayerTex_ST_zw;

				//spin player
				o.uv2 -= float2(0.5, 0.5);
				float2 spin;
				float degree = radians(_Target.w + 90);
				spin.x = o.uv2.x * cos(degree) + o.uv2.y * sin(degree);
				spin.y = o.uv2.y * cos(degree) - o.uv2.x * sin(degree);
				o.uv2 = spin;
				o.uv2 += float2(0.5, 0.5);

				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				i.uv += 0.5;
				fixed3 color;
				fixed4 trigersColor;
				if (i.uv.x > 2 || i.uv.x < 0 || i.uv.y < 0 || i.uv.y > 2){
					color = tex2D(_BgTex, i.uv).rgb;	
				} else {
					i.uv *= 0.5;
					color = tex2D(_MainTex, i.uv).rgb;	
					trigersColor = tex2D(_triggers, i.uv);
					color = lerp(color, trigersColor, trigersColor.w);
					_Target *= 0.002;
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
