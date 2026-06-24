using UnityEngine; 
// Base de Unity: permite usar MonoBehaviour y todo lo del motor

public class NarrativeManager : MonoBehaviour
// Este es el "cerebro" del sistema narrativo
// Controla qué nodo se ejecuta y el flujo de la historia
{
    public NarrativeNode currentNode;
    // Nodo que está activo actualmente (la “escena” o parte de historia que se está jugando)

    public AdditionalNarrativeScript textWriter;
    // Referencia al script que escribe texto con efecto máquina de escribir

    public void StartNarrative(NarrativeNode startNode)
    // Se llama para iniciar toda la historia desde un nodo inicial
    {
        currentNode = startNode;
        // Guarda el nodo inicial como el actual

        ExecuteCurrentNode();
        // Ejecuta lo que haga ese nodo (diálogo, evento, etc.)
    }

    public void ExecuteCurrentNode()
    // Ejecuta la lógica del nodo actual
    {
        currentNode.Execute(this);
        // Le dice al nodo: “ejecútate y usa este manager si necesitas avanzar”
    }

    public void Next(string choiceId = null)
    // Avanza al siguiente nodo según una elección del jugador
    {
        currentNode = currentNode.GetNext(choiceId);
        // Pide al nodo actual cuál es el siguiente nodo según la opción elegida

        ExecuteCurrentNode();
        // Ejecuta el nuevo nodo
    }
}