using System.Collections;
using Reflex.Attributes;
using UnityEngine;

public class Obstracle : MonoBehaviour
{
    private bool _isActive;
    [Inject] private ILevelNavigation _levelNavigation;

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

        if (other.TryGetComponent(out Player player))
        {
            _isActive = false;
            _levelNavigation.RestartLevel();
        }
    }
}