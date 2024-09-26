using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class MazeSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeX;
    [SerializeField] private TMP_Text _sizeY;

    [Inject] private LevelStorage _levelStorage;

    private void Awake()
    {
        _sizeX.text = _levelStorage.SizeMazeX.ToString();
        _sizeY.text = _levelStorage.SizeMazeY.ToString();
    }
}
