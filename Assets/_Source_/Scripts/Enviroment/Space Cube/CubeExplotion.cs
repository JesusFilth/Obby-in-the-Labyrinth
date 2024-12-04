using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplotion : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out CubeExplotion cubeExplotion))
        {

            Vector3 point = collision.contacts[0].point;

            GameObject effect = Instantiate(_effect);
            effect.transform.position = point;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
