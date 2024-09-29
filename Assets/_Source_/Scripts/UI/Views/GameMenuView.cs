using GameCreator.Runtime.Common;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameMenuView : MonoBehaviour, IGameUI
{
    private const int FirstLevelNumber = 1;

    [SerializeField] private Button _prev;
    [SerializeField] private Button _next;
    [SerializeField] private Button _play;

    [SerializeField] private TMP_Text _currentLevel;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _stars;

    private CanvasGroup _canvasGroup;
    private int _currentChoseLevel;

    [Inject] private ILevelCurrent _levelCurrent;
    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private ILevelStars _levelStars;
    [Inject] private UserStorage _userStorage;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _prev.onClick.AddListener(OnClickPrev);
        _next.onClick.AddListener(OnClickNext);
        _play.onClick.AddListener(OnClickPlay);
    }

    private void OnDisable()
    {
        _prev.onClick.RemoveListener(OnClickPrev);
        _next.onClick.RemoveListener(OnClickNext);
        _play.onClick.RemoveListener(OnClickPlay);
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

        _currentChoseLevel = _levelCurrent.GetCurrentLevel();
        UpdateData();

        TimeManager.Instance.SetTimeScale(0, 5);
    }

    private void UpdateData()
    {
        _currentLevel.text = _levelCurrent.GetCurrentLevel().ToString();
        _stars.text = _userStorage.GetLevelStars(_currentChoseLevel).ToString();
        _level.text = _userStorage.GetLevelStars(_currentChoseLevel).ToString();

        ButtonsUpdate();
    }

    private void ButtonsUpdate()
    {
        if (_currentChoseLevel == _userStorage.GetLastLevelNumber())
            _next.gameObject.SetActive(false);
        else
            _next.gameObject.SetActive(true);

        if(_currentChoseLevel == FirstLevelNumber)
            _prev.gameObject.SetActive(false);
        else 
            _prev.gameObject.SetActive(true);

    }

    private void OnClickPrev()
    {
        _currentChoseLevel = Mathf.Clamp(_currentChoseLevel - 1, 1, _userStorage.GetLastLevelNumber());
        ButtonsUpdate();
        UpdateData();
    }

    private void OnClickNext()
    {
        _currentChoseLevel = Mathf.Clamp(_currentChoseLevel + 1, 1, _userStorage.GetLastLevelNumber());
        ButtonsUpdate();
        UpdateData();
    }

    private void OnClickPlay()
    {
        _levelNavigation.OpenLevel(_currentChoseLevel);
    }
}
