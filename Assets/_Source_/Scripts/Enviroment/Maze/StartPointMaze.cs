using Reflex.Attributes;
using UnityEngine;

public class StartPointMaze : MonoBehaviour
{
    [SerializeField] private Transform _point;

    [Inject] private InitializeLevel _initLevel;

    public Transform Point => _point;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
        {
            DIGameConteiner.Instance.InjectRecursive(gameObject);
            _initLevel.AddPlayerStartPoint(this);
        }
    }
}