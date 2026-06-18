using UnityEngine;

public class TransitionExecutor : MonoBehaviour
{
    public void Execute(TransitionNode node)
    {
        TransitionManager.Instance.PlayTransition(node.TransitionType, node.Duration);
    }
}
