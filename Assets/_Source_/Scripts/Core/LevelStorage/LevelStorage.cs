using System;
using System.Linq;
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

    private bool _isFirstGame = false;

    private LevelStarModel[] _levelStars = new LevelStarModel[3]
    {
        new LevelStarModel(){ LevelNumber = 1 },
        new LevelStarModel(){ LevelNumber = 2 },
        new LevelStarModel(){ LevelNumber = 3 },
    };

    public int CurrentMaze { get; private set; } = 1;
    public int Level { get; private set; } = 1;
    public int CurrentStars { get; private set; } = 0;

    public event Action<int> StarsChanged;
    public event Action<LevelStarModel[]> StarsModelChanged;

    public bool InitGame(int level)
    {
        if (_isFirstGame)
            return false;

        _isFirstGame = true;
        Level = level;

        return true;
    }

    public bool IsLastMazeLevel() => CurrentMaze == MaxSizeForNewLevel - 1;

    public int GetMazeSizeX() => GetMazeSize();

    public int GetMazeSizeY() => GetMazeSize();

    public int GetCurrentLevel() => Level;

    public int GetCurrentMaze() => CurrentMaze;

    public int GetCurrentStars() => CurrentStars;

    public void NextMaze()
    {
        CurrentMaze++;

        if (CheckNewLevel())
        {
            CurrentMaze = 1;
            Level++;

            CurrentStars = 0;
            ClearLevelStarsModel();
        }

        NextLevel();  
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public void OpenLevel(int levelNumber)
    {
        Level = levelNumber;
        CurrentMaze = 1;
        CurrentStars = 0;

        SceneManager.LoadScene(GameSceneNames.Game);
    }

    public int GetStarCountInMaze() => StarInMaze;

    public int GetTrapsCount()
    {
        if (Level == 1)
            return 0;

        return Level + CurrentMaze;
    }

    public void AddStar(int count)
    {
        LevelStarModel starModel = _levelStars.Where(star => star.LevelNumber == CurrentMaze).FirstOrDefault();

        if (starModel == null)
            throw new ArgumentNullException(nameof(starModel));

        starModel.HasStar = true;
        CurrentStars += count;
        UpdateStars();
    }

    public void UpdateStars()
    {
        StarsModelChanged?.Invoke(_levelStars);
        StarsChanged?.Invoke(CurrentStars);
    }

    private bool CheckNewLevel()
    {
        if((CurrentMaze % MaxSizeForNewLevel) == 0)
        {
            return true;
        }

        return false;
    }

    private int GetMazeSize()
    {
        return MinMazeSize + Level;
    }

    private void ClearLevelStarsModel()
    {
        foreach (LevelStarModel starModel in _levelStars)
        {
            starModel.HasStar = false;
        }
    }
}