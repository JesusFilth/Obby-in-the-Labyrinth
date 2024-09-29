using Reflex.Attributes;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LevelInitUI : MonoBehaviour, IGameUI
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private float _delay = 3;

    private CanvasGroup _canvasGroup;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    //[Inject] private IGameProgress _progress;
    [Inject] private StateMashineUI _stateMashineUI;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void OnDisable()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;

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
