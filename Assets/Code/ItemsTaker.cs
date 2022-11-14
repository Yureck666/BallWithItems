using System.Collections;
using System.Collections.Generic;
using Models;
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
    [Inject] private InventoryModel _inventoryModel;

    private Coroutine _coroutine;

    private IEnumerator TakeItem()
    {
        while (_inventoryModel.GetItemsCountByType(itemType) > 0)
        {
            var item = _itemsStack.GetItem(itemType);
            _itemsStack.RemoveItemFromStack(item);
            item.TakeOut(_playerMove.transform.position, takePosition);
            _inventoryModel.RemoveItem(itemType, 1);

            yield return new WaitForSeconds(interval);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove _))
        {
            _coroutine = StartCoroutine(TakeItem());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove _))
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }
}