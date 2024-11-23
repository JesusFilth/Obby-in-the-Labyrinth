using GameCreator.Runtime.Common;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverUI : MonoBehaviour, IGameUI
{
    private const int MaxStarCount = 5;

    [SerializeField] private TMP_Text _levelNumber;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _replayLevel;

    [SerializeField] private StarsConteinerView _starsConteiner;

    private CanvasGroup _canvasGroup;

    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private ILevelCurrent _levelCurrent;
    [Inject] private UserStorage _userStorage;
    //[Inject] private GlueCreator _glueCreator;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

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

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        TimeManager.Instance.SetTimeScale(1, 5);
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        UpdateData();

        TimeManager.Instance.SetTimeScale(0, 5);
    }

    private void UpdateData()
    {
        int currentLevel = _levelCurrent.GetCurrentLevel();
        int stars = _levelCurrent.GetCurrentStars();

        _levelNumber.text = currentLevel.ToString();

        _starsConteiner.UpdateData(_levelCurrent.GetCurrentStars());

        _userStorage.AddLevel(currentLevel, stars);
        _userStorage.AddLevel(currentLevel + 1, 0);
    }

    private void OnClickNextLevel()
    {
        //_glueCreator.Create();
        _levelNavigation.NextMaze();
    }

    private void OnClickReplayLevel()
    {
        //_glueCreator.Create();
        _levelNavigation.RestartLevel();
    }
}
