using GamePush;
using UnityEngine;

public class InterstitialAd : MonoBehaviour
{
    private void Start()
    {
        GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);
    }

    private void OnFullscreenStart()
    {
        FocusGame.Instance.Lock();
    }

    private void OnFullscreenClose(bool succes)
    {
        FocusGame.Instance.Unlock();
    }
}