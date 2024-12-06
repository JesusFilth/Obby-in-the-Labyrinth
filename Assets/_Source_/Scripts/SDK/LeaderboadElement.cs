using GamePush;
using Reflex.Attributes;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SDK
{
    public class LeaderboadElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _playerScore;
        [SerializeField] private RawImage _icon;
        [SerializeField] private Image _panel;
        [SerializeField] private Sprite _playerPanel;

        private Coroutine _avatarLoading;

        [Inject] private UserStorage _userStorage;

        private void OnEnable()
        {
            try
            {
                Validate();
            }
            catch (ArgumentNullException ex)
            {
                enabled = false;
                throw ex;
            }
        }

        private void OnDisable()
        {
            if (_avatarLoading != null)
            {
                StopCoroutine(_avatarLoading);
                _avatarLoading = null;
            }
        }

        public void Init(LeaderboardFetchData player, int rank, bool isUser)
        {
            _rank.text = rank.ToString();
            _playerName.text = player.name;
            _playerScore.text = player.score.ToString();

            if (isUser)
                _panel.sprite = _playerPanel;

            if (_avatarLoading == null)
                _avatarLoading = StartCoroutine(LoadingImage(player.avatar));
        }

        private IEnumerator LoadingImage(string imageUrl)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    _icon.texture = texture;
                }
            }

            _avatarLoading = null;
        }

        private void Validate()
        {
            if (_rank == null)
                throw new ArgumentNullException(nameof(_rank));

            if (_playerName == null)
                throw new ArgumentNullException(nameof(_playerName));

            if (_playerScore == null)
                throw new ArgumentNullException(nameof(_playerScore));
        }
    }
}