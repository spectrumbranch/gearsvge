

float PiOver2 = 1.570796;

float4 BaseColor  = float4(0.25,1,0,1);
float Zoom = 0.75;
float Thickness = 0.05;

struct VertexShaderInput
{
    float4 Position : POSITION0;
	float2 Tex0 : TexCoord0;
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
	float2 Tex0 : TexCoord0;
};



//////////////////////////////////////////////////////////////////////////////////////////////////////////

// common vertex shader, simple passthrough
VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;
	
	output.Position = input.Position;
	output.Tex0 = input.Tex0;

    return output;
}


// simple pixel shader to render the texture
float4 PixelShaderRender(VertexShaderOutput input) : COLOR0
{	
	// remap and zoom
	float x = 2 * input.Tex0.x - 1;
	float y = 2 * input.Tex0.y - 1;
	x /= Zoom;
	y /= Zoom;
	
	// calculate implicit circle formula for x² + y² = 1;
	float implicit =  x * x + y * y;
	
	// Calculate our upper and lower bounds based on thickness.
	float lower = 1 - Thickness;
	float upper = 1;	
	
	// remap [lower;upper] to [-1,1] and effectively clamp to [lower;upper] 	
	implicit = 2 * (implicit - lower) / Thickness - 1;
	implicit = clamp(implicit, -1, 1);
	
	// distribute for smoothing/antialiassing using 1 - implicit²
	float density = 1 - (implicit * implicit);
	
	// UNUSED - this alternative fades out more gradually, but is more costly
	// distribute for antialiassing using cos(implicit * 0.5 * Pi)
	// float density = cos(implicit * PiOver2);
	
	float4 color = BaseColor;
	color.a *= density;
	
	return color;
}

// basic technique to render the texture
technique Render
{
    pass Pass1
    {        
        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderRender();
    }
}
