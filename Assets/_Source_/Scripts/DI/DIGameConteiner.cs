using Reflex.Core;
using Reflex.Extensions;
using Reflex.Injectors;
using UnityEngine;

public class DIGameConteiner : MonoBehaviour
{
    private Container _container;

    public static DIGameConteiner Instance { get; private set; }

    private void Awake()
    {
        InitHot();
    }

    public void InitHot()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
    }

    public void InjectRecursive(GameObject gameObject)
    {
        GameObjectInjector.InjectRecursive(gameObject, _container);
    }

    private void Initialize()
    {
        _container = gameObject.scene.GetSceneContainer();
    }
}