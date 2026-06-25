using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;
using UnityEditor.AssetImporters;
using UnityEngine;

[ScriptedImporter(1,GenericGraph.AssetExtension)] // Importa el GenericGraph
public class GraphImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext context)
    {
        GenericGraph genericGraph = GraphDatabase.LoadGraphForImporter<GenericGraph>(context.assetPath);//Esta importando un archivo tipo graph.
        StartNode startNode = genericGraph.GetNodes().OfType<StartNode>().FirstOrDefault();// Obtengo el primer StartNode.
        GenericRuntimeGraph runtimeGraph= ScriptableObject.CreateInstance<GenericRuntimeGraph>(); //Crea una instancia de tipo GenericRuntimeGraph que lo convierte a datos de tipo asset.
        INode nextNode = GetNextNode(startNode);//Quiero obtener el siguiente nodo(es el punto de partida).

        while(nextNode!=null)
        {
            List<GenericRuntimeNode> runtimeNodes=ConvertNodesToRuntimeNodes(nextNode); //Almaceno los nodos.
            runtimeGraph.nodes.AddRange(runtimeNodes);// Añade los runtimeNodes de golpe.
            nextNode=GetNextNode(nextNode);//Almacenar el siguiente nodo.
        }
        context.AddObjectToAsset("RuntimeGraph", runtimeGraph);// Agrega un objeto al activo con el nombre y objeto
        context.SetMainObject(runtimeGraph);// Este será el objeto principal.
    }


    static INode GetNextNode(INode node)
    {
        if(node == null) return null;
        IPort outputPort = node.GetOutputPortByName(GenericNode.OUTPUT_PORT_NAME); // Obtiene la salida del nodo actual.
        IPort nextNodePort = outputPort.firstConnectedPort;// Pasa al siguiente nodo.
        INode nextNode = nextNodePort.GetNode(); //Obtiene ese nodo.

        return nextNode;
    }

    static List<GenericRuntimeNode> ConvertNodesToRuntimeNodes(INode currentNode)
    {
        List<GenericRuntimeNode> runtimeNodes = new List<GenericRuntimeNode>();
        switch(currentNode)
        {
            case DialogueNode dialogueNode:
                runtimeNodes.Add(new DialogueRuntimeNode
                {
                    characterDialogue = GetInputPortValue<string>(dialogueNode.GetInputPortByName(dialogueNode.CharacterName)),
                    textDialogue = GetInputPortValue<string>(dialogueNode.GetInputPortByName(dialogueNode.DialogueText)) // Quiero almacenar el nombre de este puerta para luego usar en el GetInputPortValue. 
                });
                break;

            case NarrativeNode narrativeNode:    
                runtimeNodes.Add(new NarrativeRuntimeNode
                {
                    textNarrative = GetInputPortValue<string>(narrativeNode.GetInputPortByName(narrativeNode.text))
                });
                break;

            case TransitionNode transitionNode:
                runtimeNodes.Add(new TransitionRuntimeNode
                {
                    transitionTypeTransition = GetInputPortValue<TransitionType>(transitionNode.GetInputPortByName(transitionNode.TransitionType.ToString())),
                    durationTransition = GetInputPortValue<float>(transitionNode.GetInputPortByName(transitionNode.Duration.ToString()))
                });
                break;
            case EndNode endNode:
                runtimeNodes.Add(new EndRuntimeNode
                {
                    endingTitle = endNode.EndingTitle,
                    endingText = endNode.EndingText
                });
                break;
        }
        return runtimeNodes;
    }

    static T GetInputPortValue<T>(IPort port)
    {
        T value = default;
        if(port.isConnected)// Si esta conectado.
        {
            switch(port.firstConnectedPort.GetNode())
            {
                case IVariableNode variableNode:// Si es una variable.
                    variableNode.variable.TryGetDefaultValue<T>(out value);//Te da el valor por defecto que tiene el nodo.
                    return value;
                    break;
                case IConstantNode constantNode: //Si es una constante.
                    constantNode.TryGetValue<T>(out value);//Lo mismo solo que es en una constante.
                    return value;
                    break;
                default:
                    break;
            }
        }
        else
        {
            port.TryGetValue(out value);//Si esta desconectado.
        }
        return value;
    }
}