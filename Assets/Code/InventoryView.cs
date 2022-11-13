using System;
using TMPro;
using UnityEngine;

namespace Views
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private TMP_Text counter;

        private void Awake()
        {
            counter.text = "";
        }

        public void SetCounterText(string text)
        {
            counter.text = text;
        }
    }
}