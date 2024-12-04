using UnityEngine;
using Random = UnityEngine.Random;

public class CubeRotate : MonoBehaviour
{
    [SerializeField] private float _speed = 250f;
    [SerializeField] private Vector3 _direction = Vector3.forward;
    [SerializeField] private bool _isRandom = true;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        if(_isRandom)
            Initialize();
    }

    private void Update()
    {
        _transform.Rotate(_direction, _speed * Time.deltaTime);
    }

    private void Initialize()
    {
        _speed = Random.Range(1,3);

        _direction = new Vector3(
            Random.Range(-1,1),
            Random.Range(-1, 1),
            Random.Range(-1, 1));
    }
}
