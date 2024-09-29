using UnityEngine.SceneManagement;

public class LoadGameSceneState : IGameState
{
    public void Execute()
    {
        SceneManager.LoadScene(GameSceneNames.Game);
    }
}