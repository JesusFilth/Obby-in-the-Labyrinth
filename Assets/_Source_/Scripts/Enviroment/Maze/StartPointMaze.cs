using Reflex.Attributes;
using UnityEngine;

public class StartPointMaze : MonoBehaviour
{
    [SerializeField] private Transform _point;

    public Transform Point  => _point;

    [Inject] private InitializeLevel _initLevel;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
        {
            DIGameConteiner.Instance.InjectRecursive(gameObject);
            _initLevel.AddPlayerStartPoint(this);
        }
    }
}
