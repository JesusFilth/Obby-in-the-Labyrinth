using System;
using GamePush;

public class BootstrapState : IGameState
{
    private readonly GameStateMashine _stateMashine;

    public BootstrapState(GameStateMashine stateMashine)
    {
        if (stateMashine == null)
            throw new ArgumentNullException(nameof(stateMashine));

        _stateMashine = stateMashine;
    }

    public async void Execute()
    {
        await GP_Init.Ready;
        OnInitialized();
    }

    private void OnInitialized()
    {
        _stateMashine.EnterIn<LoadDataState>();
    }
}