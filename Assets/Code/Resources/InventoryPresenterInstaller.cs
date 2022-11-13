using Presenters;
using UnityEngine;
using Zenject;

public class InventoryPresenterInstaller : MonoInstaller
{
    [SerializeField] private InventoryPresenter inventoryPresenter;
    public override void InstallBindings()
    {
        Container.Bind<InventoryPresenter>().FromInstance(inventoryPresenter).AsSingle().NonLazy();
    }
}