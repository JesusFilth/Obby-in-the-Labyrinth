using UnityEngine;

namespace qtools.qmaze.example2
{
	[RequireComponent(typeof(Camera))]
	public class QTPSCamera : MonoBehaviour 
	{
        [SerializeField] private float _distance = 10.0f;
        [SerializeField] private float _rotationSpeed = 20.0f;
        [SerializeField] private float _height = 5.0f;
        [SerializeField] private float _verticalOffsetAngle = 30.0f;

        public Transform targetTransform;
		public Vector3 offset = new Vector3(-0.4f, 11f, 3.8f);
		public float lerp = 0.4f;

        private float _currentAngle;
		private Transform _transform;
		private bool _isCompleted;

		private void Start()
		{
            _transform = targetTransform;

            _transform.position = targetTransform.position + offset;
            _transform.rotation = Quaternion.LookRotation(targetTransform.position - transform.position);
		}

		private void LateUpdate()
		{
			if (_isCompleted)
			{
				RoatationPlayer();
            }
			else
			{
				FallowPlayer();
            }
		}

        public void ToCompleted()
        {
            _currentAngle = transform.eulerAngles.y;
            _isCompleted = true;
        }

        private void FallowPlayer()
		{
            if (targetTransform == null)
                return;

            _transform.position = Vector3.Lerp(_transform.position, targetTransform.position, lerp * Time.deltaTime);
            transform.position = _transform.position + offset;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetTransform.position - transform.position), lerp * Time.deltaTime);
        }

		private void RoatationPlayer()
		{
            Debug.Log("Rotation");
            _currentAngle += _rotationSpeed * Time.unscaledDeltaTime;
            Quaternion rotation = Quaternion.Euler(0, _currentAngle, 0);

            Vector3 positionOffset = new Vector3(0, _height, -_distance);
            Vector3 desiredPosition = targetTransform.position + rotation * positionOffset;

            transform.position = desiredPosition;

            Vector3 targetPosition = targetTransform.position + new Vector3(0, _verticalOffsetAngle, 0);
            transform.LookAt(targetPosition);
        }
	}
}