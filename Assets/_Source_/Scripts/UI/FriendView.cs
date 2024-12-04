using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FriendView : MonoBehaviour
{
    [SerializeField] private int _level;

    private Image _image;

    public int LevelNumber => _level;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void On()
    {
        _image.color = new Color32(255, 255, 255, 255);
    }

    public void Off()
    {
        _image.color = new Color32(0, 0, 0, 255);
    }
}