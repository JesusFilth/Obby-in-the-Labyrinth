using UnityEngine;

public class GlueCreator : MonoBehaviour
{
    [SerializeField] private GluingUI _glue;

    public void Create()
    {
        Instantiate(_glue);
    }
}
