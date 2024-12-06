using System.Collections;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class LevelInitUI : GameView
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private float _delay = 3;

    private Coroutine _coroutine;

    [Inject] private StateMashineUI _stateMashineUI;
    private WaitForSeconds _waitForSeconds;

    private void OnEnable()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public override void Hide()
    {
        SetCanvasVisibility(false);
    }

    public override void Show()
    {
        SetCanvasVisibility(true);

        //_level.text = _progress.GetPlayerProgress().LevelCount.ToString();

        if (_coroutine == null)
            _coroutine = StartCoroutine(Showing());
    }

    private IEnumerator Showing()
    {
        yield return _waitForSeconds;

        _stateMashineUI.EnterIn<GameLevelUIState>();
        _coroutine = null;
    }
}