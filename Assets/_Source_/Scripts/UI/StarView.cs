using UnityEngine;

public class StarView : MonoBehaviour
{
    [SerializeField] private GameObject _starIcon;

    public void On() => _starIcon.SetActive(true);
}