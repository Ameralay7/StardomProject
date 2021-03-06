﻿Shader "Custom/AtlasClipShader (SoftClip)" 
{
  Properties 
  {
    _MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
    _AlphaTex ("MaskTexture", 2D) = "white" {}
  }
 
  SubShader
  {
    LOD 100
 
    Tags{
      "Queue" = "Transparent"
      "IgnoreProjector" = "True"
      "RenderType" = "Transparent"
    }
     Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Offset -1, -1
			Fog { Mode Off }
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
 
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
 
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _AlphaTex;
 
			struct appdata
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 clipcoord : TEXCOORD2;
			};
 
			struct v2f
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 worldPos : TEXCOORD1;
				float2 clipcoord : TEXCOORD2;
			};
 
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = v.color;
				o.texcoord = v.texcoord;
				o.clipcoord = v.clipcoord;
				o.worldPos = TRANSFORM_TEX(v.vertex.xy, _MainTex);
				return o;
			}
 
			half4 frag (v2f IN) : COLOR
			{
				// Sample the texture
				half4 col = tex2D(_MainTex, IN.texcoord) * IN.color;
				half4 a2 = tex2D(_AlphaTex, IN.clipcoord);
 
				float2 factor = abs(IN.worldPos);
				float val = 1.0 - max(factor.x, factor.y);
 
				// Option 1: 'if' statement
				//if (val < 0.0) col.a = 0.0;
				//if (a2.a < col.a) col.a = a2.a;
 
				// Option 2: no 'if' statement -- may be faster on some devices
				//col.a *= ceil(clamp(val, 0.0, 1.0));
				
				col.a *= a2.a * ceil(clamp(val, 0.0, 1.0));
				//col = float4(a2.x, a2.y, 1, 1);

				return col;
			}
			ENDCG
		}
  }
}