using GameCreator.Runtime.Common;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class LifeRewardUI : GameView
{
    [SerializeField] private Button _rewardBtn;
    [SerializeField] private Button _continueBtn;

    [Inject] private StateMashineUI _gameUI;

    private bool _isHasLife;

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

    public override void Hide()
    {
        SetCanvasVisibility(false);
    }

    public override void Show()
    {
        if (_isHasLife)
        {
            _gameUI.EnterIn<GameOverUIState>();
            return;
        }

        SetCanvasVisibility(true);

        TimeManager.Instance.SetTimeScale(0, 5);
    }

    private void ShowReward()
    {
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