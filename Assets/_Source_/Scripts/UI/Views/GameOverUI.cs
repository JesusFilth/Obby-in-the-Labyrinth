using GameCreator.Runtime.Common;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : GameView
{
    private const int MaxStarCount = 5;

    [SerializeField] private TMP_Text _levelNumber;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _replayLevel;

    [SerializeField] private StarsConteinerView _starsConteiner;
    [Inject] private ILevelCurrent _levelCurrent;

    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private UserStorage _userStorage;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(OnClickNextLevel);
        _replayLevel.onClick.AddListener(OnClickReplayLevel);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(OnClickNextLevel);
        _replayLevel.onClick.RemoveListener(OnClickReplayLevel);
    }

    public override void Hide()
    {
        SetCanvasVisibility(false);
        TimeManager.Instance.SetTimeScale(1, 5);
    }

    public override void Show()
    {
        SetCanvasVisibility(true);
        UpdateData();

        TimeManager.Instance.SetTimeScale(0, 5);
    }

    private void UpdateData()
    {
        var currentLevel = _levelCurrent.GetCurrentLevel();
        var stars = _levelCurrent.GetCurrentStars();

        _levelNumber.text = currentLevel.ToString();

        _starsConteiner.UpdateData(_levelCurrent.GetCurrentStars());

        _userStorage.AddLevel(currentLevel, stars);
        _userStorage.AddLevel(currentLevel + 1, 0);
    }

    private void OnClickNextLevel()
    {
        _levelNavigation.NextMaze();
    }

    private void OnClickReplayLevel()
    {
        _levelNavigation.RestartLevel();
    }
}