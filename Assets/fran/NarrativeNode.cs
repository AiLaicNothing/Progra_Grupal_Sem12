using System; 

using UnityEngine;

[Serializable]
// Permite que el nodo se pueda visualizar y editar en el Inspector.

public class NarrativeNode : GenericNode
// Define un nodo narrativo que hereda de GenericNode.

{
    public string NarrativeText;
    // Guarda el texto narrativo que se mostrará al jugador.
    // Este texto no pertenece a un personaje específico.

    protected override void OnDefinePorts(IPortDefinitionContext context)
    // Define cómo se conecta este nodo dentro del sistema de narrativa.

    {
        context.AddInputPort(INPUT_PORT_NAME).Build();
        // Puerto de entrada: permite que otro nodo lo active.

        context.AddOutputPort(OUTPUT_PORT_NAME).Build();
        // Puerto de salida: permite continuar al siguiente nodo.
    }
}