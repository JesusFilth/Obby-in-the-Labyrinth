using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class StarsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [Inject] private Player _player;

    private void OnEnable()
    {
        _player.StarsChanged += UpdateData;
    }

    private void OnDisable()
    {
        _player.StarsChanged -= UpdateData;
    }

    private void UpdateData(int value)
    {
        _text.text = value.ToString();
    }
}
