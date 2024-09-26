using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLevel;
    [SerializeField] private TMP_Text _nextLevel;
    [SerializeField] private TMP_Text _currentMaze;
    [SerializeField] private Slider _slider;

    [Inject] private LevelStorage _levelStorage;

    private void Awake()
    {
        _currentLevel.text = _levelStorage.Level.ToString();
        _nextLevel.text = (_levelStorage.Level + 1).ToString();

        _currentMaze.text = _levelStorage.CurrentMaze.ToString();

        _slider.value = _levelStorage.CurrentMaze;
    }
}
