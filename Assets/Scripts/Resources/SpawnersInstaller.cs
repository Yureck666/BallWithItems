using UnityEngine;
using Zenject;

namespace BallGame.Resources
{
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
}