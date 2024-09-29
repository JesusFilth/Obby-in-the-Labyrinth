using Agava.YandexGames;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LederboardView : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const int MaxElements = 7;

    [SerializeField] private LeaderboadElement _prefab;
    [SerializeField] private Transform _conteiner;

    private List<LeaderboardPlayer> _leaderboardPlayers = new();
    private List<LeaderboadElement> _leaderboadElements = new();

    private void OnEnable()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        UpdateData();
        CreateElements();
#endif
    }

    private void UpdateData()
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        _leaderboardPlayers.Clear();

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                int rank = entry.rank;
                int score = entry.score;
                string name = entry.player.publicName;

                //if (string.IsNullOrEmpty(name))
                //    name = _localizationTranslate.GetAnonymousName();

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardPlayers.OrderByDescending(player => player.Rank).ToList();
            //_leaderboadrView.Construct(_leaderboardPlayers.Take(MaxPlayers).ToList());
        });
    }

    private void CreateElements()
    {
        ClearElements();

        for (int i = 0; i < MaxElements; i++)
        {
            LeaderboadElement temp = Instantiate(_prefab, _conteiner);
            temp.Init(
                _leaderboardPlayers[i].Rank.ToString(),
                _leaderboardPlayers[i].Name,
                _leaderboardPlayers[i].Score.ToString());

            _leaderboadElements.Add(temp);
        }
    }

    private void ClearElements()
    {
        foreach (LeaderboadElement element in _leaderboadElements)
        {
            Destroy(element.gameObject);
        }
    }
}
