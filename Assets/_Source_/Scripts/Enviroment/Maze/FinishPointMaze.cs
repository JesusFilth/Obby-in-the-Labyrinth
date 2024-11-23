using Reflex.Attributes;
using UnityEngine;

public class FinishPointMaze : MonoBehaviour
{
    [SerializeField] private ParticleSystem _portal;
    [SerializeField] private Color _lastLevel;

    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private StateMashineUI _stateMashineUI;
    //[Inject] private GlueCreator _glueCreator;

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
        if (_levelNavigation.IsLastMazeLevel())
        {
            var mainPrticle = _portal.main;
            mainPrticle.startColor = _lastLevel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            if (_levelNavigation.IsLastMazeLevel())
            {
                _stateMashineUI.EnterIn<GameOverUIState>();
            }
            else
            {
                //_glueCreator.Create();
                _levelNavigation.NextMaze();
            }
        }
    }
}
