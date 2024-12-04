using UnityEngine;

public class EnviromentObject : MonoBehaviour
{
    [SerializeField] private int _levelNeed;

    public int LevelNeed => _levelNeed;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}