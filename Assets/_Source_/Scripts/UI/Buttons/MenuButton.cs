using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : ButtonView
{
    protected override void OnClick()
    {
        StateMashine.EnterIn<GameMenuStateUI>();
    }
}
