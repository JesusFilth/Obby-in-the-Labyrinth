using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 30f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        var rotationAmount = _speed * Time.deltaTime;

        _transform.Rotate(rotationAmount, 0, 0);

        if (_transform.rotation.eulerAngles.x >= 360f)
        {
            var eulerRotation = _transform.rotation.eulerAngles;
            eulerRotation.x -= 360f;
            _transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}