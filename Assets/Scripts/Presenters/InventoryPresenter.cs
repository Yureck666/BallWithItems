using System.Text;
using BallGame.Models;
using BallGame.Views;
using UnityEngine;
using Zenject;

namespace BallGame.Presenters
{
    public class InventoryPresenter:MonoBehaviour
    {
        [SerializeField] private InventoryView view;

        [Inject] private InventoryModel _model;

        private void Awake()
        {
            _model.OnModelChange.AddListener(arg0 => RefreshCounterText());
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