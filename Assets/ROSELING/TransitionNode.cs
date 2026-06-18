using System;
using UnityEngine;

[Serializable]
public class TransitionNode : GenericNode
{
    public TransitionType TransitionType;
    public float Duration = 1f;

    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort(INPUT_PORT_NAME).Build();
        context.AddOutputPort(OUTPUT_PORT_NAME).Build();
    }

}