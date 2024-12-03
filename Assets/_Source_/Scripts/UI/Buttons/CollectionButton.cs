public class CollectionButton : ButtonView
{
    protected override void OnClick()
    {
        StateMashine.EnterIn<CollectionUIState>();
    }
}
