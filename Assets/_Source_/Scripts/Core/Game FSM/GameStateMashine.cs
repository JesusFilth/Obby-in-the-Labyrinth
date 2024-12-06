using System;
using System.Collections.Generic;

public class GameStateMashine
{
    private IGameState _currentState;
    private readonly Dictionary<Type, IGameState> _states;

    public GameStateMashine()
    {
        _states = new Dictionary<Type, IGameState>
        {
            [typeof(BootstrapState)] = new BootstrapState(this),
            [typeof(LoadDataState)] = new LoadDataState(this),
            [typeof(LoadGameSceneState)] = new LoadGameSceneState()
        };
    }

    public void EnterIn<TState>()
        where TState : IGameState
    {
        if (_states.TryGetValue(typeof(TState), out var state))
        {
            _currentState = state;
            _currentState.Execute();
        }
    }
}