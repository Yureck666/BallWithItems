using System.Text;
using Models;
using UnityEngine;
using Views;

namespace Presenters
{
    public class InventoryPresenter:MonoBehaviour
    {
        [SerializeField] private InventoryView view;

        private InventoryModel _model;

        private void Awake()
        {
            _model = new InventoryModel();
        }

        public int GetItemsCountByType(ItemType type)
        {
            return _model.GetItemsCountByType(type);
        }

        public void AddItem(ItemType item, int count)
        {
            _model.AddItem(item, count);
            RefreshCounterText();
        }

        public void RemoveItem(ItemType item, int count)
        {
            _model.RemoveItem(item, count);
            RefreshCounterText();
        }

        private void RefreshCounterText()
        {
            var items = _model.Items;
            var text = new StringBuilder();
            foreach (var (item, count) in items)
            {
                text.Append(item.ToString());
                text.Append(": ");
                text.Append(count);
                text.Append("\n");
            }

            view.SetCounterText(text.ToString());
        }
    }
}