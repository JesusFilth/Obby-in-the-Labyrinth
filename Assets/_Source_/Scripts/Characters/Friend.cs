using GameCreator.Runtime.VisualScripting;
using UnityEngine;

public class Friend : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Actions _actions;

    private bool _isOpen;

    public void ShowCompleted()
    {
        _actions?.Invoke();
    }

    public void Open()
    {
        _isOpen = true;
    }
}
