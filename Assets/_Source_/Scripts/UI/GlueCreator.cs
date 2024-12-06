using UnityEngine;

public class GlueCreator : MonoBehaviour
{
    [SerializeField] private GluingUI _glue;

    private void Start()
    {
        Instantiate(_glue);
    }

    public void Create()
    {
        Instantiate(_glue);
    }
}