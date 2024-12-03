using Reflex.Attributes;
using UnityEngine;

public class StartGamePoint : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;

    private void Start()
    {
        _stateMashine.EnterIn<BootstrapState>();
    }
}