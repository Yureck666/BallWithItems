using BallGame.Models;
using BallGame.Presenters;
using UnityEngine;
using Zenject;

namespace BallGame.Resources
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private InventoryPresenter inventoryPresenter;
        public override void InstallBindings()
        {
            Container.Bind<InventoryPresenter>().FromInstance(inventoryPresenter).AsSingle();
        
            var inventoryModel = new InventoryModel();
            Container.Bind<InventoryModel>().FromInstance(inventoryModel).AsSingle();
        }
    }
}