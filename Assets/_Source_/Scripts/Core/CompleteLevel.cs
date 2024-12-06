using GameCreator.Runtime.VisualScripting;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private Actions _actions;

    public void Show(Friend friend)
    {
        friend.ShowCompleted();
        _actions?.Invoke();
    }
}