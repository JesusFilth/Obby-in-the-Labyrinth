using Reflex.Attributes;
using UnityEngine;

public class StarsConteinerView : MonoBehaviour
{
    private const int MaxStar = 3;

    [SerializeField] private StarView[] _stars = new StarView[MaxStar];

    [Inject] private ILevelStars _levelStars;

    private void OnEnable()
    {
        _levelStars.StarsModelChanged += UpdateData;
    }

    private void OnDisable()
    {
        _levelStars.StarsModelChanged -= UpdateData;
    }

    private void Start()
    {
        _levelStars.UpdateStars();
    }

    private void OnValidate()
    {
        if(_stars.Length != MaxStar)
            _stars = new StarView[MaxStar];
    }

    private void UpdateData(LevelStarModel[] starsModel)
    {
        for (int i = 0; i < _stars.Length; i++)
        {
            if (starsModel[i].HasStar)
                _stars[i].On();
        }
    }
}
