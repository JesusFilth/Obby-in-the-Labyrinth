using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStorage : MonoBehaviour
{
    private const int MaxSizeForNewLevel = 5;

    public int CurrentMaze { get; private set; } = 0;
    public int Level { get; private set; } = 1;
    public int SizeMazeX { get; private set; } = 5;
    public int SizeMazeY { get; private set; } = 5;

    public void NextLevel()
    {
        CurrentMaze++;
        CheckNewLevel();

        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public void CheckNewLevel()
    {
        if((CurrentMaze % MaxSizeForNewLevel) == 0)
        {
            SizeMazeX++;
            SizeMazeY++;

            CurrentMaze = 0;
            Level++;
        }
    }
}
