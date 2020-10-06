Shader "Unlit/FirstShader"
{
   Properties
    {

    }
    SubShader
    {
        Pass
        {            
            CGPROGRAM
            #pragma vertex VertexFunction
            #pragma fragment FragmentFunction 
            
           struct VertexData
            {
                float4 vertexPosition : POSITION;
            };
            struct FragmentData
            {
                float4 vertexPosition : SV_POSITION;
            };
            FragmentData VertexFunction(VertexData input)
            {
                FragmentData output;
                output.vertexPosition = input.vertexPosition;
                return output;
            }
            float4 FragmentFunction(FragmentData input) : SV_TARGET
            {
                return float4(1, 1, 1, 1);
            }
            ENDCG
            
        }
    }
}
