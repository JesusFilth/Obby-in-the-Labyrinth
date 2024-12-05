public class MenuButton : ButtonView
{
    protected override void OnClick()
    {
        StateMashine.EnterIn<GameMenuStateUI>();
    }
}
