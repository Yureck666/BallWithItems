using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Models
{
    public class InventoryModel
    {
        private Dictionary<ItemType, int> _items;
        
        public Dictionary<ItemType, int> Items => _items;

        public InventoryModel()
        {
            _items = new Dictionary<ItemType, int>();
        }

        public void AddItem(ItemType item, int count)
        {
            if (_items.ContainsKey(item))
                _items[item] += count;
            else
                _items.Add(item, count);
        }

        public void RemoveItem(ItemType item, int count)
        {
            if (_items.ContainsKey(item) && _items[item] >= count)
            {
                _items[item] -= count;
                if (_items[item] <= 0)
                {
                    _items.Remove(item);
                }
            }
        }

        public int GetItemsCountByType(ItemType type)
        {
            return _items.ContainsKey(type)?_items[type]:0;
        }
    }
}
