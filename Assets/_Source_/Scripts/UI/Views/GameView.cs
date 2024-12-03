using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class GameView : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    public abstract void Hide();

    public abstract void Show();

    protected void SetCanvasVisibility(bool isActive)
    {
        _canvasGroup.alpha = isActive ? 1 : 0;
        _canvasGroup.interactable = isActive;
        _canvasGroup.blocksRaycasts = isActive;
    }
}
