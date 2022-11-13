using Presenters;
using UnityEngine;
using Zenject;

public class ItemsSpawner : MonoBehaviour
{
    [Inject] private ItemsProvider _itemsProvider;
    [Inject] private DiContainer _container;
    [Inject] private ItemsStack _itemsStack;
    [Inject] private InventoryPresenter _inventoryPresenter;

    public Item SpawnItem(ItemType itemType)
    {
        var item = _container.InstantiatePrefab(_itemsProvider.GetPrefab(itemType)).GetComponent<Item>();
        item.Init(() =>
        {
            _itemsStack.BackItemToStack(item);
            _inventoryPresenter.AddItem(item.ItemType, 1);
        });
        return item;
    }
}