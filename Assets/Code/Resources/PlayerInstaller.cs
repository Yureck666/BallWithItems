using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerMove playerMove;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMove>().FromInstance(playerMove).AsSingle().NonLazy();
    }
}