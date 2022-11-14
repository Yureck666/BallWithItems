using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
    public class ItemsDistributor: MonoBehaviour
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private float interval;
        [SerializeField] private Transform spawnPosition;
        
        [Inject] private ItemsStack _itemsStack;
        [Inject] private PlayerMove _playerMove;

        private Coroutine _coroutine;

        private IEnumerator GetItem()
        {
            while (true)
            {
                var item = _itemsStack.GetItem(itemType);
                _itemsStack.RemoveItemFromStack(item);
                item.Collect(spawnPosition.position, _playerMove.transform);

                yield return new WaitForSeconds(interval);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMove _))
            {
                _coroutine = StartCoroutine(GetItem());
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
}