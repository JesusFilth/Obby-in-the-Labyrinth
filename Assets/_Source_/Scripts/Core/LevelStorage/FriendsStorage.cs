using System.Collections.Generic;
using UnityEngine;

public class FriendsStorage : MonoBehaviour
{
    [SerializeField] private List<Friend> friends = new List<Friend>();

    public Friend GetFriend(int level)
    {
        level--;

        if(level < 0 || level > friends.Count - 1)
            return friends[0];

        return friends[level];
    }
}
