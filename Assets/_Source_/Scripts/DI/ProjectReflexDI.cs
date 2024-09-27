using Reflex.Core;
using UnityEngine;

public class ProjectReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private LevelStorage _levelStorage;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(
            _levelStorage,
            typeof(ILevelCurrent),
            typeof(ILevelNavigation),
            typeof(ILevelStars));
    }
}
