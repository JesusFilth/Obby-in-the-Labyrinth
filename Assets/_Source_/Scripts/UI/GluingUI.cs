using System.Collections;
using UnityEngine;

public class GluingUI : MonoBehaviour
{
    [SerializeField] private float _delay = 2;

    private Coroutine _destroing;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Destroy(gameObject, _delay);
    }

    private IEnumerator Destroying()
    {
        yield return new WaitForSeconds(_delay);

        Destroy(gameObject);
    }
}
