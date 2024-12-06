using UnityEngine;

public class AroundPlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 10.0f;
    [SerializeField] private float _rotationSpeed = 20.0f;
    [SerializeField] private float _height = 5.0f;
    [SerializeField] private float _verticalOffsetAngle = 30.0f;

    private float _currentAngle;

    private void LateUpdate()
    {
        if (_target == null)
            return;

        _currentAngle += _rotationSpeed * Time.unscaledDeltaTime;
        var rotation = Quaternion.Euler(0, _currentAngle, 0);

        var positionOffset = new Vector3(0, _height, -_distance);
        var desiredPosition = _target.position + rotation * positionOffset;

        transform.position = desiredPosition;

        var targetPosition = _target.position + new Vector3(0, _verticalOffsetAngle, 0);
        transform.LookAt(targetPosition);
    }

    private void OnEnable()
    {
        _currentAngle = transform.eulerAngles.y;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}