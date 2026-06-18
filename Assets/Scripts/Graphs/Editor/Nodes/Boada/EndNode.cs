using System;
using Unity.GraphToolkit.Editor;

[Serializable]
public class EndNode : GenericNode
{
    public string EndingTitle;
    public string EndingText;

    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort(INPUT_PORT_NAME).Build();
    }
}