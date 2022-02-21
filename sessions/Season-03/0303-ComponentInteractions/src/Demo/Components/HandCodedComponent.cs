using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Demo.Components {

public class HandCodedComponent : ComponentBase
{

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {

        builder.AddContent(1, "Hello from Hand Coded Component");

        base.BuildRenderTree(builder);
    }

}

}