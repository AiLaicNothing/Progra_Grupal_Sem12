using UnityEngine;

public interface ITransitionObserver
{
    void OnTransitionRequested(TransitionType transitionType, float duration);
}
