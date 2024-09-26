using System.Collections;
using System.Collections.Generic;
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
        float rotationAmount = _speed * Time.deltaTime;

        _transform.Rotate(0, rotationAmount, 0);

        if (_transform.rotation.eulerAngles.y >= 360f)
        {
            Vector3 eulerRotation = _transform.rotation.eulerAngles;
            eulerRotation.y -= 360f;
            _transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}
