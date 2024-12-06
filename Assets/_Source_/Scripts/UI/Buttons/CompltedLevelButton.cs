using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CompltedLevelButton : MonoBehaviour
{
    private Button _button;

    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private StateMashineUI _stateMashineUI;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (_levelNavigation.IsLastMazeLevel())
            _stateMashineUI.EnterIn<GameOverUIState>();
        else
            _levelNavigation.NextMaze();
    }
}