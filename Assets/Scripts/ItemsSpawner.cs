using BallGame.Models;
using UnityEngine;
using Zenject;

namespace BallGame
{
    public class ItemsSpawner : MonoBehaviour
    {
        [Inject] private ItemsProvider _itemsProvider;
        [Inject] private DiContainer _container;
        [Inject] private ItemsStack _itemsStack;
        [Inject] private InventoryModel _inventoryModel;

        public Item SpawnItem(ItemType itemType)
        {
            var item = _container.InstantiatePrefab(_itemsProvider.GetPrefab(itemType)).GetComponent<Item>();
            item.Init(() =>
            {
                _itemsStack.BackItemToStack(item);
                _inventoryModel.AddItem(item.ItemType, 1);
            });
            return item;
        }
    }
}