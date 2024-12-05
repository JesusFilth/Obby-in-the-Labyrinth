public class RaitingButton : ButtonView
{
    protected override void OnClick()
    {
        StateMashine.EnterIn<RaitingUIState>();
    }
}
