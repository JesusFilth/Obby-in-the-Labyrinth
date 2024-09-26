using GameCreator.Runtime.Characters;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Character _character;

    public int Star { get; private set; } = 0;

    public event Action<int> StarsChanged;

    private void Start()
    {
        StarsChanged?.Invoke(Star);
    }

    public void SetPosition(Transform position)
    {
        _character.Driver.SetPosition(position.position);
    }

    public void AddStar(int value)
    {
        Debug.Log("Add Star");
        Star += value;
        StarsChanged?.Invoke(Star);
    }
}
