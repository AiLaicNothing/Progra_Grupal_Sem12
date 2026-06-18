using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayTransition(TransitionType transitionType,float duration)
    {
        Debug.Log($"Playing transition: {transitionType} - Duration: {duration}");
    }
}