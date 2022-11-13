using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Models;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/ItemsProvider", fileName = "ItemsProvider")]
public class ItemsProvider : ScriptableObject
{
    [SerializeField] private ItemPair[] items;
    
    [Serializable]
    class ItemPair
    {
        [SerializeField] private ItemType item;
        [SerializeField] private Item itemPrefab;

        public ItemType Item => item;
        public Item ItemPrefab => itemPrefab;
    }
    
    [CanBeNull]
    public Item GetPrefab(ItemType itemType)
    {
        return items.First(pair => pair.Item == itemType).ItemPrefab;
    }
}
