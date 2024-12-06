using System.Collections.Generic;
using System.Linq;
using GamePush;
using Reflex.Attributes;
using UnityEngine;

namespace SDK
{
    public class LederboardView : MonoBehaviour
    {
        private const string AnanimNameRU = "Аноним";
        private const string AnanimNameEU = "Anonymous";
        private const string AnanimNameTR = "Anonim";

        private const string Score = "score";
        private const int MaxElements = 4;

        [SerializeField] private LeaderboadElement _prefab;
        [SerializeField] private Transform _conteiner;

        private List<LeaderboadElement> _leaderboadElements = new();

        [Inject] private UserStorage _userStorage;

        private int _userId;
        private string _userName;

        private void OnEnable()
        {
            GP_Leaderboard.OnFetchSuccess += OnFetchSuccess;
        }

        private void OnDisable()
        {
            GP_Leaderboard.OnFetchSuccess -= OnFetchSuccess;
        }

        private void Awake()
        {
            _userId = GP_Player.GetID();
            _userName = GP_Player.GetName();
        }

        public void Fetch() => GP_Leaderboard.Fetch("", Score, Order.DESC, MaxElements);

        private void OnFetchSuccess(string fetchTag, GP_Data data)
        {
            Clear();

            List<LeaderboardFetchData> players = data.GetList<LeaderboardFetchData>();

            if(players.Where(player => player.id == _userId).FirstOrDefault() == null)
            {
                players[players.Count-1] = new LeaderboardFetchData()
                { 
                    name = _userName,
                    score = (int)GP_Player.GetScore(),
                    avatar = GP_Player.GetAvatarUrl()
                };
            }

            for (int i = 0; i < players.Count; i++)
            {
                LeaderboadElement temp = Instantiate(_prefab, _conteiner);

                if (string.IsNullOrEmpty(players[i].name))
                    players[i].name = GetAnonymousName();

                temp.Init(
                    players[i],
                    (i + 1),
                    players[i].id == _userId);

                _leaderboadElements.Add(temp);
            }
        }

        private void Clear()
        {
            foreach (LeaderboadElement element in _leaderboadElements)
            {
                Destroy(element.gameObject);
            }
        }

        private string GetAnonymousName()
        {
            Language language = GP_Language.Current();

            switch (language)
            {
                case Language.English:
                    return AnanimNameEU;

                case Language.Russian:
                    return AnanimNameRU;

                case Language.Turkish:
                    return AnanimNameTR;
            }

            return AnanimNameEU;
        }
    }
}
