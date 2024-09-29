using Agava.YandexGames;
using UnityEngine;

public class LeaderboardAutorizationCheck : MonoBehaviour
{
    [SerializeField] private LederboardView _lederboar;
    [SerializeField] private GameObject _checkAuth;

    private void OnEnable()
    {
        Check();
    }

    public void Check()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
         if (PlayerAccount.IsAuthorized)
        {
            _lederboar.gameObject.SetActive(true);
            _checkAuth.SetActive(false);
        }
#endif
    }
}