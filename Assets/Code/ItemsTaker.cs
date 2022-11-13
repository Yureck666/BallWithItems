using System.Collections;
using System.Collections.Generic;
using Presenters;
using UnityEngine;
using Zenject;

public class ItemsTaker : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private float interval;
    [SerializeField] private Transform takePosition;
        
    [Inject] private ItemsStack _itemsStack;
    [Inject] private PlayerMove _playerMove;
    [Inject] private InventoryPresenter _inventoryPresenter;

    private bool _playerIsInTrigger;
    private float _nextGet;


    private void FixedUpdate()
    {
        if (Time.time >= _nextGet && _playerIsInTrigger && _inventoryPresenter.GetItemsCountByType(itemType) > 0)
        {
            var item = _itemsStack.GetItem(itemType);
            _itemsStack.RemoveItemFromStack(item);
            item.TakeOut(_playerMove.transform.position, takePosition);
            _inventoryPresenter.RemoveItem(itemType, 1);

            _nextGet = Time.time + interval;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove player))
        {
            _playerIsInTrigger = true;
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove player))
        {
            _playerIsInTrigger = false;
        }
    }
}