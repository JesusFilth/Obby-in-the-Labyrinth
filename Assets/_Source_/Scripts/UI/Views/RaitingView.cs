using SDK;
using UnityEngine;

public class RaitingView : GameView
{
    [SerializeField] private LederboardView _view;

    public override void Hide()
    {
        SetCanvasVisibility(false);
    }

    public override void Show()
    {
        SetCanvasVisibility(true);

        _view.Fetch();
    }
}
