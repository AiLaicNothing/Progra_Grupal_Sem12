using System; 

using UnityEngine;

[Serializable]
// Permite que este nodo pueda verse y guardarse correctamente en el Inspector.

public class DialogueNode : GenericNode
// Define un nodo de diálogo que hereda de GenericNode (estructura base de nodos).

{
    public string CharacterName;
    // Guarda el nombre del personaje que está hablando.

    public Sprite CharacterPortrait;
    // Guarda la imagen del personaje para mostrarla en la UI de diálogo.

    public string DialogueText;
    // Guarda el texto del diálogo.
    // NO tiene lógica de animación aquí, solo almacena el contenido.

    protected override void OnDefinePorts(IPortDefinitionContext context)
    // Define las conexiones del nodo dentro del sistema de grafos.

    {
        context.AddInputPort(INPUT_PORT_NAME).Build();
        // Crea un puerto de entrada para que este nodo reciba conexión desde otro nodo.

        context.AddOutputPort(OUTPUT_PORT_NAME).Build();
        // Crea un puerto de salida para conectar este nodo con el siguiente.
    }
}