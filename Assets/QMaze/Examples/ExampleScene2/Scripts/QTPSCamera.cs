using UnityEngine;
using System.Collections;

namespace qtools.qmaze.example2
{
	[RequireComponent(typeof(Camera))]
	public class QTPSCamera : MonoBehaviour 
	{
		public Transform targetTransform;
		public Vector3 offset = new Vector3(-0.4f, 11f, 3.8f);
		public Vector3 levelCompleted = new Vector3(-0.4f, 4f, -1.0f);
		public float lerp = 0.4f;

		private Vector3 targetPosition;

		private void Start()
		{
			targetPosition = targetTransform.position;

			transform.position = targetTransform.position + offset;
			transform.rotation = Quaternion.LookRotation(targetTransform.position - transform.position);
		}

		private void LateUpdate()
		{
			if (targetTransform == null) return;

			targetPosition = Vector3.Lerp(targetPosition, targetTransform.position, lerp * Time.deltaTime);

			transform.position = targetPosition + offset;

			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetTransform.position - transform.position), lerp * Time.deltaTime);
		}

		public void ToCompleted()
		{
			offset = levelCompleted;
        }
	}
}