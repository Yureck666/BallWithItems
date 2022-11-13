using System;
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

        private bool _playerIsInTrigger;
        private float _nextGet;


        private void FixedUpdate()
        {
            if (Time.time >= _nextGet && _playerIsInTrigger)
            {
                var item = _itemsStack.GetItem(itemType);
                _itemsStack.RemoveItemFromStack(item);
                item.Collect(spawnPosition.position, _playerMove.transform);

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
}