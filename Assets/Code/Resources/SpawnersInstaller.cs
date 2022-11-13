using Code;
using UnityEngine;
using Zenject;

public class SpawnersInstaller : MonoInstaller
{
    [SerializeField] private DistributorSpawner distributorSpawner;
    [SerializeField] private TakerSpawner takerSpawner;
    public override void InstallBindings()
    {
        Container.Bind<DistributorSpawner>().FromInstance(distributorSpawner).AsSingle();
        Container.Bind<TakerSpawner>().FromInstance(takerSpawner).AsSingle();
    }
}