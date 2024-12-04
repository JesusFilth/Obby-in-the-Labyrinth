using System.Collections.Generic;
using UnityEngine;

public class FriendsStorage : MonoBehaviour
{
    [SerializeField] private List<Friend> _friends = new List<Friend>();

    public int Count => _friends.Count;

    public Friend GetFriend(int level)
    {
        level--;

        if(level < 0 || level > _friends.Count - 1)
            return _friends[0];

        return _friends[level];
    }
}
