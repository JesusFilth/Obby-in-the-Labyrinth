using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FriendsStorage : MonoBehaviour
{
    [SerializeField] private List<Friend> _friends = new();

    public int Count => _friends.Count;

    public Friend GetFriend(int level)
    {
        level--;

        if (level < 0 || level > _friends.Count - 1)
            return _friends[Random.Range(0, _friends.Count)];

        return _friends[level];
    }
}