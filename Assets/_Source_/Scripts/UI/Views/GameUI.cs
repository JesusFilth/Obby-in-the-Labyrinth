using GameCreator.Runtime.Common;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameUI : MonoBehaviour, IGameUI
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;

        TimeManager.Instance.SetTimeScale(1, 5);
    }
}
