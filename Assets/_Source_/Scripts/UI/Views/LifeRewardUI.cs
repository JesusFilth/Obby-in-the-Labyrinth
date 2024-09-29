using GameCreator.Runtime.Common;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class LifeRewardUI : MonoBehaviour, IGameUI
{
    [SerializeField] private Button _rewardBtn;
    [SerializeField] private Button _continueBtn;

    private CanvasGroup _canvasGroup;
    private bool _isHasLife;

    [Inject] private StateMashineUI _gameUI;
    //[Inject] private IGamePlayer _player;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    private void OnEnable()
    {
        _rewardBtn.onClick.AddListener(ShowReward);
        _continueBtn.onClick.AddListener(ToContinue);
    }

    private void OnDisable()
    {
        _rewardBtn.onClick.RemoveListener(ShowReward);
        _continueBtn.onClick.RemoveListener(ToContinue);
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        if (_isHasLife)
        {
            _gameUI.EnterIn<GameOverUIState>();
            return;
        }

        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        TimeManager.Instance.SetTimeScale(0, 5);
    }

    private void ShowReward()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRevardCallback, OnCloseCallback);
#else
        OnRevardCallback();
#endif
    }

    private void ToContinue()
    {
        _gameUI.EnterIn<GameOverUIState>();
    }

    private void OnOpenCallback()
    {
        FocusGame.Instance.Lock();
    }

    private void OnCloseCallback()
    {
        FocusGame.Instance.Unlock();
    }

    private void OnRevardCallback()
    {
        _isHasLife = true;
        //_player.Resurrect();

        _gameUI.EnterIn<GameLevelUIState>();
    }
}
