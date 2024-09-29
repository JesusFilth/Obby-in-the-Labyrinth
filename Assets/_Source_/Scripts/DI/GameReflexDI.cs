using Reflex.Core;
using UnityEngine;

public class GameReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private InitializeLevel _initializeLevel;
    [SerializeField] private Player _player;
    [SerializeField] private StateMashineUI _stateMashineUI;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_initializeLevel);
        containerBuilder.AddSingleton(_player);
        containerBuilder.AddSingleton(_stateMashineUI);
    }
}
