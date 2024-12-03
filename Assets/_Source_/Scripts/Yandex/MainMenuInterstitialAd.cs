using UnityEngine;

public class MainMenuInterstitialAd : MonoBehaviour
{
    private void Start()
    {
    }

    private void OnOpenAdCallback()
    {
        FocusGame.Instance.Lock();
    }

    private void OnCloseAdCallback(bool wasShown)
    {
        FocusGame.Instance.Unlock();
    }
}