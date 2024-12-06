using UnityEngine;

public class CubeExplotion : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CubeExplotion cubeExplotion))
        {
            var point = collision.contacts[0].point;

            var effect = Instantiate(_effect);
            effect.transform.position = point;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}