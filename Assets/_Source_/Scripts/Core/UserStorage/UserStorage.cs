using System;
using System.Linq;
using GamePush;
using UnityEngine;

public class UserStorage
{
    private const string GoldKey = "gold";
    private const string LevelKey = "level-model";

    public void AddLevel(int level, int currentStars)
    {
        string json = GP_Player.GetString(LevelKey);

        if (string.IsNullOrEmpty(json))
        {
            CreateDafaultLevels(level, currentStars);
            Save();

            return;
        }

        LevelModel[] levelModels = JsonUtility.FromJson<LevelModel[]>(json);
        LevelModel levelFind = levelModels.Where(lvl => lvl.Number == level).FirstOrDefault();

        if (levelFind == null)
        {
            Array.Resize(ref levelModels, levelModels.Length + 1);
            levelModels[levelModels.Length - 1] = new LevelModel() { Number = level, Stars = currentStars };
        }
        else
        {
            if (levelFind.Stars < currentStars)
                levelFind.Stars = currentStars;
        }

        json = JsonUtility.ToJson(levelModels);

        GP_Player.Set(LevelKey, json);

        Save();
    }

    public int GetLevelStars(int levelNumber)
    {
        string json = GP_Player.GetString(LevelKey);

        if (string.IsNullOrEmpty(json))
        {
            CreateDafaultLevels(1, 0);
            Save();

            return 0;
        }

        LevelModel[] levelModels = JsonUtility.FromJson<LevelModel[]>(json);
        LevelModel levelFind = levelModels.Where(lvl => lvl.Number == levelNumber).FirstOrDefault();

        if (levelFind == null)
            throw new ArgumentNullException(nameof(levelFind));

        return levelFind.Stars;
    }

    public int GetLastLevelNumber()
    {
        string json = GP_Player.GetString(LevelKey);

        if (string.IsNullOrEmpty(json))
        {
            CreateDafaultLevels(1, 0);
            Save();

            return 1;
        }

        LevelModel[] levelModels = JsonUtility.FromJson<LevelModel[]>(json);

        return levelModels.Length;
    }

    public void AddScore(int score)
    {
        GP_Player.AddScore(score);

        Save();
    }

    public void ToDefault()
    {
        CreateDafaultLevels(1,0);
        Save();
    }

    private void CreateDafaultLevels(int level, int stars)
    {
        LevelModel[] levelModels = new LevelModel[1];
        levelModels[0] = new LevelModel() { Number = level, Stars = stars };

        string json = JsonUtility.ToJson(levelModels);
        GP_Player.Set(LevelKey, json);
    }

    private void Save()
    {
        GP_Player.Sync();
    }
}