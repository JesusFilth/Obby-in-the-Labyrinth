using Reflex.Attributes;
using UnityEngine;

public class FinishPointMaze : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private Friend _currentFriend;

    [Inject] private ILevelNavigation _levelNavigation;
    [Inject] private StateMashineUI _stateMashineUI;//?
    [Inject] private FriendsStorage _friendsStorage;//?
    [Inject] private ILevelCurrent _levelCurrent;
    [Inject] private CompleteLevel _completeLevel;

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
        _currentFriend = Instantiate(friend, _spawnPoint, false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _completeLevel.Show(_currentFriend);

            //if (_levelNavigation.IsLastMazeLevel())
            //{
            //    _stateMashineUI.EnterIn<GameOverUIState>();
            //}
            //else
            //{
            //    _levelNavigation.NextMaze();
            //}
        }
    }
}
