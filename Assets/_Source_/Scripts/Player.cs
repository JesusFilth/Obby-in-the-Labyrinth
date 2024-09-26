using GameCreator.Runtime.Characters;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Character _character;

    public void SetPosition(Transform position)
    {
        _character.Driver.SetPosition(position.position);
    }
}
