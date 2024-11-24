using Reflex.Attributes;
using UnityEngine;

public class FinishPointMaze : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private StateMashineUI _stateMashineUI;
    [Inject] private FriendsStorage _friendsStorage;
    [Inject] private ILevelCurrent _levelCurrent;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
        {
            DIGameConteiner.Instance.InjectRecursive(gameObject);
        }
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Friend friend = _friendsStorage.GetFriend(_levelCurrent.GetCurrentLevel());
        Instantiate(friend, _spawnPoint, false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            if (_levelNavigation.IsLastMazeLevel())
            {
                _stateMashineUI.EnterIn<GameOverUIState>();
            }
            else
            {
                _levelNavigation.NextMaze();
            }
        }
    }
}
