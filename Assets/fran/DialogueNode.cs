using System;
using UnityEngine;

[Serializable]
public class DialogueNode : GenericNode
{
    // Nombre del personaje que está hablando.
    public string CharacterName;

    // Texto que dirá el personaje.
    public string DialogueText;

    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        // Puerto de entrada principal.
        // Permite que otro nodo se conecte a este.
        context.AddInputPort(INPUT_PORT_NAME).Build();

        // Puerto de salida principal.
        // Permite continuar al siguiente nodo.
        context.AddOutputPort(OUTPUT_PORT_NAME).Build();
    }
}