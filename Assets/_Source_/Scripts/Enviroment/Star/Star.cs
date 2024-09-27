using System.Collections;
using UnityEngine;

public class Star : MonoBehaviour
{
    private const int Value = 1;

    private bool _isActive = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive == false)
            return;

        if(other.TryGetComponent(out Player player))
        {
            _isActive = false;
            player.AddStar(Value);
            Destroy(gameObject);
        }
    }
}
