using GameCreator.Runtime.Common;

public class GameLevelUI : GameView
{
    public override void Hide()
    {
        SetCanvasVisibility(false);
    }

    public override void Show()
    {
        SetCanvasVisibility(true);
        TimeManager.Instance.SetTimeScale(1, 5);
    }
}