using System.Collections.Generic;
using GameCreator.Runtime.Common;
using Reflex.Attributes;
using UnityEngine;

public class CollectionView : GameView
{
    [SerializeField] private List<FriendView> _friends = new();

    [Inject] private UserStorage _userStorage;

    public override void Hide()
    {
        SetCanvasVisibility(false);
        TimeManager.Instance.SetTimeScale(1, 5);
    }

    public override void Show()
    {
        SetCanvasVisibility(true);
        UpdateData();

        TimeManager.Instance.SetTimeScale(0, 5);
    }

    private void UpdateData()
    {
        foreach (var friend in _friends)
            if (_userStorage.HasFriend(friend.LevelNumber) == false)
                friend.Off();
            else
                friend.On();
    }
}