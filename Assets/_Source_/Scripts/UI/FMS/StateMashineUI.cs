using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMashineUI : MonoBehaviour
{
    [SerializeField] private GameView _gameUI;
    [SerializeField] private GameView _menu;
    [SerializeField] private GameView _rewardLifeUI;
    [SerializeField] private GameView _gameOverUI;
    [SerializeField] private GameView _collectionUI;
    [SerializeField] private GameView _raitingUI;

    private GameUIState _currentState;
    private Dictionary<Type, GameUIState> _states;

    private void Awake()
    {
        Initialize();
    }

    public void EnterIn<TState>()
        where TState : GameUIState
    {
        if (_states.TryGetValue(typeof(TState), out var state))
        {
            _currentState?.Close();
            _currentState = state;
            _currentState.Open();
        }
    }

    private void Initialize()
    {
        _states = new Dictionary<Type, GameUIState>
        {
            [typeof(GameLevelUIState)] = new GameLevelUIState(_gameUI),
            [typeof(GameMenuStateUI)] = new GameMenuStateUI(_menu),
            [typeof(LifeRewardUIState)] = new LifeRewardUIState(_rewardLifeUI),
            [typeof(GameOverUIState)] = new GameOverUIState(_gameOverUI),
            [typeof(CollectionUIState)] = new CollectionUIState(_collectionUI),
            [typeof(RaitingUIState)] = new RaitingUIState(_raitingUI)
        };

        EnterIn<GameLevelUIState>();
    }
}