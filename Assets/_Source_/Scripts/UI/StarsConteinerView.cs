using Reflex.Attributes;
using UnityEngine;

public class StarsConteinerView : MonoBehaviour
{
    private const int MaxStar = 3;

    [SerializeField] private StarView[] _stars = new StarView[MaxStar];

    [Inject] private ILevelStars _levelCurrent;

    private void OnEnable()
    {
        _levelCurrent.StarsChanged += UpdateData;
    }

    private void OnDisable()
    {
        _levelCurrent.StarsChanged -= UpdateData;
    }

    private void OnValidate()
    {
        if (_stars.Length != MaxStar)
            _stars = new StarView[MaxStar];
    }

    public void UpdateData(int star)
    {
        ClearStars();

        for (var i = 0; i < star; i++)
            _stars[i].On();
    }

    private void ClearStars()
    {
        foreach (var star in _stars)
            star.Off();
    }
}