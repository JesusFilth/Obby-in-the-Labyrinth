using Reflex.Core;
using UnityEngine;

public class GameReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private InitializeLevel _initializeLevel;
    [SerializeField] private Player _player;
    [SerializeField] private StateMashineUI _stateMashineUI;
    [SerializeField] private CompleteLevel _completeLevel;
    [SerializeField] private GlueCreator _glueCreator;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_completeLevel);
        containerBuilder.AddSingleton(_initializeLevel);
        containerBuilder.AddSingleton(_player);
        containerBuilder.AddSingleton(_stateMashineUI);
        containerBuilder.AddSingleton(_glueCreator);
    }
}