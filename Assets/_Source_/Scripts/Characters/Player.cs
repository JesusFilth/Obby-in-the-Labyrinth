using GameCreator.Runtime.Characters;
using Reflex.Attributes;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Character _character;

    [Inject] private ILevelStars _levelStars;

    public void SetPosition(Transform position)
    {
        _character.Driver.SetPosition(position.position);
    }

    public void AddStar(int value)
    {
        _levelStars.AddStar(value);
    }
}