using Reflex.Attributes;
using UnityEngine;

public class FinishPointMaze : MonoBehaviour
{
    [SerializeField] private ParticleSystem _portal;
    [SerializeField] private Color _lastLevel;

    [Inject] private LevelStorage _levelStorage;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
        {
            DIGameConteiner.Instance.InjectRecursive(gameObject);
        }

        ChangeColarChange();
    }

    private void ChangeColarChange()
    {
        if (_levelStorage.IsLastMazeLevel())
        {
            var mainPrticle = _portal.main;
            mainPrticle.startColor = _lastLevel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _levelStorage.NextLevel();
        }
    }
}
