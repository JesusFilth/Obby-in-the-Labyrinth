using Agava.YandexGames;
using System;
using System.Linq;
using UnityEngine;

public class UserStorage
{
    private const string UserKey = "User";
    private const string LeaderboardName = "Leaderboard";

    private UserModel _user;

    public event Action<int> GoldChanged;

    public void SetUser(UserModel user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _user = user;
    }

    public void AddLevel(int level, int currentStars)
    {
        LevelModel levelFind = _user.Levels.Where(lvl => lvl.Number == level).FirstOrDefault();

        if(levelFind == null)
        {
            Array.Resize(ref _user.Levels, _user.Levels.Length+1);
            _user.Levels[_user.Levels.Length - 1] = new LevelModel() { Number = level, Stars = currentStars };
        }
        else
        {
            if(levelFind.Stars < currentStars)
                levelFind.Stars = currentStars;
        }

        Save();
    }

    public void AddGold(int value)
    {
        _user.Gold += value;
        GoldChanged?.Invoke(_user.Gold);
        Save();
    }

    public void AddScore(int score)
    {
        if(_user.Score < score)
            _user.Score = score;

        Save();
        UpdatePlayerScore();
    }

    public void UpdateGold()
    {
        GoldChanged.Invoke(_user.Gold);
    }

    private void UpdatePlayerScore()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
   if (PlayerAccount.IsAuthorized == false)
            return;

        int score = _user.Score;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null || result.score < score)
                Leaderboard.SetScore(LeaderboardName, score);
        });
#endif
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(_user);
        PlayerPrefs.SetString(UserKey, json);
        PlayerPrefs.Save();

#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(json);
#endif
    }
}