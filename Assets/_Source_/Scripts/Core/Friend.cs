using GameCreator.Runtime.VisualScripting;
using UnityEngine;

public class Friend : MonoBehaviour
{
    [SerializeField] private Actions _actions;

    public void ShowCompleted()
    {
        _actions?.Invoke();
    }
}
