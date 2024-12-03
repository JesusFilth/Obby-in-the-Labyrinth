using GameCreator.Runtime.Common;

public class CollectionView : GameView
{
    public override void Hide()
    {
        SetCanvasVisibility(false);
        TimeManager.Instance.SetTimeScale(1, 5);
    }

    public override void Show()
    {
        SetCanvasVisibility(true);

        UpdateData();

        TimeManager.Instance.SetTimeScale(0, 5);
    }

    private void UpdateData()
    {

    }
}
