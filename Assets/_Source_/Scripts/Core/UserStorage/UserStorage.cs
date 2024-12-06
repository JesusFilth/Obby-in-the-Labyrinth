using System;
using System.Linq;
using GamePush;
using UnityEngine;

public class UserStorage
{
    private const string GoldKey = "gold";
    private const string LevelKey = "level-model";

    private const int MaxStars = 3;

    public void AddLevel(int level, int currentStars)
    {
        var json = GP_Player.GetString(LevelKey);

        if (string.IsNullOrEmpty(json))
        {
            CreateDafaultLevels(level, currentStars);
            Save();

            return;
        }

        var levelModelStorage = JsonUtility.FromJson<LevelModelStorage>(json);
        var levelFind = levelModelStorage.Levels.Where(lvl => lvl.Number == level).FirstOrDefault();

        if (levelFind == null)
        {
            Array.Resize(ref levelModelStorage.Levels, levelModelStorage.Levels.Length + 1);
            levelModelStorage.Levels[levelModelStorage.Levels.Length - 1] =
                new LevelModel { Number = level, Stars = currentStars };
        }
        else
        {
            if (levelFind.Stars < currentStars)
            {
                levelFind.Stars = currentStars;
                UpdateScore(levelModelStorage);
            }
        }

        json = JsonUtility.ToJson(levelModelStorage);

        GP_Player.Set(LevelKey, json);

        Save();
    }

    public int GetLevelStars(int levelNumber)
    {
        var json = GP_Player.GetString(LevelKey);

        if (string.IsNullOrEmpty(json))
        {
            CreateDafaultLevels(1, 0);
            Save();

            return 0;
        }

        var levelModelStorage = JsonUtility.FromJson<LevelModelStorage>(json);
        var levelFind = levelModelStorage.Levels.Where(lvl => lvl.Number == levelNumber).FirstOrDefault();

        if (levelFind == null)
            throw new ArgumentNullException(nameof(levelFind));

        return levelFind.Stars;
    }

    public int GetLastLevelNumber()
    {
        var json = GP_Player.GetString(LevelKey);

        if (string.IsNullOrEmpty(json))
        {
            CreateDafaultLevels(1, 0);
            Save();

            return 1;
        }

        var levelModelStorage = JsonUtility.FromJson<LevelModelStorage>(json);
        return levelModelStorage.Levels.Length;
    }

    public void ToDefault()
    {
        CreateDafaultLevels(1, 0);
        Save();
    }

    public bool HasFriend(int level)
    {
        var json = GP_Player.GetString(LevelKey);

        if (string.IsNullOrEmpty(json))
            return false;

        var levelModelStorage = JsonUtility.FromJson<LevelModelStorage>(json);
        var levelFind = levelModelStorage.Levels.Where(lvl => lvl.Number == level).FirstOrDefault();

        if (levelFind == null)
            return false;

        return levelFind.Stars == MaxStars;
    }

    private void UpdateScore(LevelModelStorage levelModelStorage)
    {
        var score = levelModelStorage.Levels.Sum(stars => stars.Stars);
        GP_Player.AddScore(score);
    }

    private void CreateDafaultLevels(int level, int stars)
    {
        var levelModels = new LevelModel[1];
        levelModels[0] = new LevelModel { Number = level, Stars = stars };

        var levelModelStorage = new LevelModelStorage { Levels = levelModels };

        var json = JsonUtility.ToJson(levelModelStorage);
        GP_Player.Set(LevelKey, json);
    }

    private void Save()
    {
        GP_Player.Sync();
    }
}