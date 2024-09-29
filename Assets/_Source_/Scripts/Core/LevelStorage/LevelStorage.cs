using Reflex.Attributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStorage : MonoBehaviour,
    ILevelCurrent,
    ILevelNavigation,
    ILevelStars
{
    private const int StarInMaze = 1;
    private const int MaxSizeForNewLevel = 6;

    [Inject] private UserStorage _userStorage;

    public int CurrentMaze { get; private set; } = 1;
    public int Level { get; private set; } = 1;
    public int SizeMazeX { get; private set; } = 5;
    public int SizeMazeY { get; private set; } = 5;
    public int CurrentStars { get; private set; } = 0;

    public event Action<int> StarsChanged;

    public bool IsLastMazeLevel() => CurrentMaze == MaxSizeForNewLevel - 1;

    public int GetMazeSizeX() => SizeMazeX;

    public int GetMazeSizeY() => SizeMazeY;

    public int GetCurrentLevel() => Level;

    public int GetCurrentMaze() => CurrentMaze;

    public void NextLevel()
    {
        CurrentMaze++;
        CheckNewLevel();

        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public int GetStarCount() => StarInMaze;

    public int GetTrapsCount()
    {
        if (Level == 1)
            return 0;

        return Level * CurrentMaze;
    }

    public void AddStar(int count)
    {
        CurrentStars += count;
        UpdateStars();
    }

    public void UpdateStars() => StarsChanged?.Invoke(CurrentStars);

    private void CheckNewLevel()
    {
        if((CurrentMaze % MaxSizeForNewLevel) == 0)
        {
            if(_userStorage != null)
                _userStorage.AddLevel(Level, CurrentStars);

            SizeMazeX++;
            SizeMazeY++;

            CurrentMaze = 1;
            Level++;

            CurrentStars = 0;
        }
    }
}