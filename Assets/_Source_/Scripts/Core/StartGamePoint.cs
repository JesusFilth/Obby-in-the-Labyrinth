using Reflex.Attributes;
using UnityEngine;

public class StartGamePoint : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;
    [Inject] private UserStorage _userStorage;

    private void Start()
    {
        _stateMashine.Init(_userStorage);
        _stateMashine.EnterIn<BootstrapState>();
    }
}