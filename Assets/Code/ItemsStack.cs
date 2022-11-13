using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

public class ItemsStack : MonoBehaviour
{
    [SerializeField] private ItemsCountInStack[] itemsCountInStack;
    [SerializeField] private Vector3 stackPosition;

    [Inject] private ItemsSpawner _itemsSpawner;

    private Dictionary<ItemType, Stack> _stacks;

    [Serializable]
    private class ItemsCountInStack
    {
        [SerializeField] private ItemType type;
        [SerializeField] private int count;

        public ItemType Type => type;
        public int Count => count;
    }

    private class Stack
    {
        private List<Item> _items;

        public void Init()
        {
            _items = new List<Item>();
        }

        [CanBeNull]
        public Item GetItem()
        {
            return _items.First();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public int GetCount()
        {
            return _items.Count;
        }
    }

    public Item GetItem(ItemType type)
    {
        var item = _stacks[type].GetItem();
        if (item == null)
        {
            item = _itemsSpawner.SpawnItem(type);
            item.transform.SetParent(transform);
        }

        return item;
    }

    public void RemoveItemFromStack(Item item)
    {
        _stacks[item.ItemType].RemoveItem(item);
    }

    public void BackItemToStack(Item item)
    {
        var type = item.ItemType;
        if (_stacks[type].GetCount() < itemsCountInStack.First(stack => stack.Type == type).Count)
        {
            _stacks[type].AddItem(item);
            item.transform.SetParent(transform);
            item.transform.position = stackPosition;
        }
        else
        {
            Destroy(item.gameObject);
        }
    }

    private void Awake()
    {
        _stacks = new Dictionary<ItemType, Stack>();
        
        CleanItemsCountInStack();
        foreach (var countInStack in itemsCountInStack)
        {
            var stack = new Stack();
            stack.Init();
            for (int i = 0; i < countInStack.Count; i++)
            {
                var item = _itemsSpawner.SpawnItem(countInStack.Type);
                stack.AddItem(item);
                item.transform.SetParent(transform);
                item.transform.position = stackPosition;
            }
            _stacks.Add(countInStack.Type, stack);
        }
    }

    private void CleanItemsCountInStack()
    {
        if (itemsCountInStack == null) return;
        var items = new List<ItemsCountInStack>();
        foreach (var countInStack in itemsCountInStack)
        {
            if (items.Any(item1 => item1.Type == countInStack.Type)) continue;
            items.Add(countInStack);
        }

        itemsCountInStack = items.ToArray();
    }
}