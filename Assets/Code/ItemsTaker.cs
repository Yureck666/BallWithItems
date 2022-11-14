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

    private Coroutine _coroutine;
    
    private IEnumerator TakeItem()
    {
        while (true)
        {
            var item = _itemsStack.GetItem(itemType);
            _itemsStack.RemoveItemFromStack(item);
            item.TakeOut(_playerMove.transform.position, takePosition);
            _inventoryPresenter.RemoveItem(itemType, 1);

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
            StopCoroutine(_coroutine);
        }
    }
}