using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class MazeSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeX;
    [SerializeField] private TMP_Text _sizeY;

    [Inject] private ILevelCurrent _levelCurrent;

    private void Awake()
    {
        _sizeX.text = _levelCurrent.GetMazeSizeX().ToString();
        _sizeY.text = _levelCurrent.GetMazeSizeY().ToString();
    }
}
