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

    [SerializeField] private StarsConteinerView _starsConteiner;

    [Inject] private ILevelCurrent _levelCurrent;

    private void Start()
    {
        _currentLevel.text = _levelCurrent.GetCurrentLevel().ToString();
        _nextLevel.text = (_levelCurrent.GetCurrentLevel() + 1).ToString();
        _currentMaze.text = _levelCurrent.GetCurrentMaze().ToString();
        _slider.value = _levelCurrent.GetCurrentMaze() - 1;

        _starsConteiner.UpdateData(_levelCurrent.GetCurrentStars());
    }
}