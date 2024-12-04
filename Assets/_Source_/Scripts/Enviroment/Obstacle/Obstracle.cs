using Reflex.Attributes;
using System.Collections;
using UnityEngine;

public class Obstracle : MonoBehaviour
{
    [Inject] private ILevelNavigation _levelNavigation;

    private bool _isActive = false;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        _isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive == false)
            return;

        if(other.TryGetComponent(out Player player))
        {
            _isActive = false;
            _levelNavigation.RestartLevel();
        }
    }
}
