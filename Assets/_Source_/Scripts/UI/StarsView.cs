using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class StarsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [Inject] private ILevelStars _levelStars;

    private void OnEnable()
    {
        _levelStars.StarsChanged += UpdateData;
        _levelStars.UpdateStars();
    }

    private void OnDisable()
    {
        _levelStars.StarsChanged -= UpdateData;
    }

    private void UpdateData(int value)
    {
        _text.text = value.ToString();
    }
}
