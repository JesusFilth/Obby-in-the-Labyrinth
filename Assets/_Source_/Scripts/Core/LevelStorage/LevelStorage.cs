using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStorage : MonoBehaviour,
    ILevelCurrent,
    ILevelNavigation,
    ILevelStars
{
    private const int StarInMaze = 1;
    private const int MaxSizeForNewLevel = 4;
    private const int MinMazeSize = 4;

    private bool _isFirstGame;

    private bool IsTakeStar;

    public int CurrentMaze { get; private set; } = 1;
    public int Level { get; private set; } = 1;
    public int CurrentStars { get; private set; }

    public void InitGame(int level)
    {
        IsTakeStar = false;

        if (_isFirstGame)
            return;

        _isFirstGame = true;
        Level = level;
    }

    public int GetMazeSizeX()
    {
        return GetMazeSize();
    }

    public int GetMazeSizeY()
    {
        return GetMazeSize();
    }

    public int GetCurrentLevel()
    {
        return Level;
    }

    public int GetCurrentMaze()
    {
        return CurrentMaze;
    }

    public int GetCurrentStars()
    {
        return CurrentStars;
    }

    public int GetStarCountInMaze()
    {
        return StarInMaze;
    }

    public int GetTrapsCount()
    {
        if (Level == 1)
            return 0;

        return Level - 1 + CurrentMaze;
    }

    public bool IsLastMazeLevel()
    {
        return CurrentMaze == MaxSizeForNewLevel - 1;
    }

    public void NextMaze()
    {
        CurrentMaze++;

        if (CheckNewLevel())
        {
            CurrentMaze = 1;
            Level++;

            CurrentStars = 0;
        }

        NextLevel();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public void RestartLevel()
    {
        if (IsTakeStar)
            CurrentStars = Mathf.Clamp(0, CurrentStars - 1, 3);

        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public void OpenLevel(int levelNumber)
    {
        Level = levelNumber;
        CurrentMaze = 1;
        CurrentStars = 0;

        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public event Action<int> StarsChanged;

    public void AddStar(int count)
    {
        IsTakeStar = true;
        CurrentStars += count;
        StarsChanged?.Invoke(CurrentStars);
    }

    private bool CheckNewLevel()
    {
        if (CurrentMaze % MaxSizeForNewLevel == 0) return true;

        return false;
    }

    private int GetMazeSize()
    {
        return MinMazeSize + Level;
    }
}