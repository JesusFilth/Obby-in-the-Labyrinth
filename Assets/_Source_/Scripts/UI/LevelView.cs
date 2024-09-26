using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [Inject] private LevelStorage _levelStorage;

    private void Awake()
    {
        _text.text = _levelStorage.Level.ToString();
    }
}
