using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStorage : MonoBehaviour
{
    public int Level { get; private set; } = 1;
    public int SizeMazeX { get; private set; } = 5;
    public int SizeMazeY { get; private set; } = 5;

    public void NextLevel()
    {
        SizeMazeX++;
        SizeMazeY++;

        Level++;

        SceneManager.LoadScene(GameSceneNames.Game);
    }
}
