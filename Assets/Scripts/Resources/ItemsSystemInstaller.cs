using UnityEngine;
using Zenject;

namespace BallGame.Resources
{
    [CreateAssetMenu(fileName = "ItemsProviderInstaller", menuName = "Installers/ItemsProviderInstaller")]
    public class ItemsSystemInstaller : MonoInstaller
    {
        [SerializeField] private ItemsProvider itemsProvider;
        [SerializeField] private ItemsSpawner itemsSpawner;
        [SerializeField] private ItemsStack itemsStack;
        public override void InstallBindings()
        {
            Container.Bind<ItemsProvider>().FromInstance(itemsProvider).AsSingle();
        
            Container.Bind<ItemsSpawner>().FromInstance(itemsSpawner).AsSingle();
        
            Container.Bind<ItemsStack>().FromInstance(itemsStack).AsSingle();
        }
    }
}