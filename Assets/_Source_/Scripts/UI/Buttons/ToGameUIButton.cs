using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToGameUIButton : ButtonView
{
    protected override void OnClick()
    {
        StateMashine.EnterIn<GameLevelUIState>();
    }
}