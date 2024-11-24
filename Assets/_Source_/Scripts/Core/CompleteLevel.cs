using GameCreator.Runtime.VisualScripting;
using Reflex.Attributes;
using System.Collections;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private float _delay = 3f;
    [SerializeField] private Actions _actions;

    private Coroutine _coroutine;

    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private StateMashineUI _stateMashineUI;


    public void Show(Friend friend)
    {
        friend.ShowCompleted();
        StartCoroutine(Showing());
    }

    private IEnumerator Showing()
    {
        _actions?.Invoke();

        yield return new WaitForSeconds(_delay);

        Finish();
    }

    public void Finish()
    {
        if (_levelNavigation.IsLastMazeLevel())
        {
            _stateMashineUI.EnterIn<GameOverUIState>();
        }
        else
        {
            _levelNavigation.NextMaze();
        }
    }
}
