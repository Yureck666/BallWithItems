using System.Collections.Generic;
using UnityEngine.Events;

namespace BallGame.Models
{
    public class InventoryModel
    {
        private Dictionary<ItemType, int> _items;
        
        public Dictionary<ItemType, int> Items => _items;
        
        public UnityEvent<InventoryModel> OnModelChange { get; private set; }

        public InventoryModel()
        {
            _items = new Dictionary<ItemType, int>();
            OnModelChange = new UnityEvent<InventoryModel>();
        }

        public void AddItem(ItemType item, int count)
        {
            if (_items.ContainsKey(item))
                _items[item] += count;
            else
                _items.Add(item, count);
            
            OnModelChange.Invoke(this);
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
                
                OnModelChange.Invoke(this);
            }
        }

        public int GetItemsCountByType(ItemType type)
        {
            return _items.ContainsKey(type)?_items[type]:0;
        }
    }
}