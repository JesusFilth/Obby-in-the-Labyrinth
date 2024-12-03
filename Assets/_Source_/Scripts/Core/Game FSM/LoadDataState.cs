using System;

public class LoadDataState : IGameState
{
    private readonly GameStateMashine _stateMashine;

    public LoadDataState(GameStateMashine stateMashine)
    {
        if (stateMashine == null)
            throw new ArgumentNullException(nameof(stateMashine));

        _stateMashine = stateMashine;
    }

    public void Execute()
    {
        Load();
    }

    private void Load()
    {
        _stateMashine.EnterIn<LoadGameSceneState>();
    }

    private UserModel GetDefaultUser()
    {
        UserModel userModel = new UserModel()
        {
            Name = "Player",
            Gold = 100,
            Score = 0,
        };

        userModel.Levels = new LevelModel[1];
        userModel.Levels[0] = new LevelModel() { Number = 1, Stars = 0 };

        return userModel;
    }
}