using UnityEngine;

public class StarRotate : MonoBehaviour
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

        _transform.Rotate(0, rotationAmount, 0);

        if (_transform.rotation.eulerAngles.y >= 360f)
        {
            var eulerRotation = _transform.rotation.eulerAngles;
            eulerRotation.y -= 360f;
            _transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}