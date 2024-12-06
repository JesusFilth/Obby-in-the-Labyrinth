using Reflex.Attributes;
using UnityEngine;

public class FinishPointMaze : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [Inject] private CompleteLevel _completeLevel;

    private Friend _currentFriend;

    [Inject] private FriendsStorage _friendsStorage;
    [Inject] private ILevelCurrent _levelCurrent;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null) DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void Start()
    {
        Initialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player)) _completeLevel.Show(_currentFriend);
    }

    private void Initialize()
    {
        var friend = _friendsStorage.GetFriend(_levelCurrent.GetCurrentLevel());
        _currentFriend = Instantiate(friend, _spawnPoint, false);
    }
}