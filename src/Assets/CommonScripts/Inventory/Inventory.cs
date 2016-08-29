using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CommonScripts.Inventory
{
    // 
    //  TODO - Stacks of multiple identical items
    public class Inventory
    {
        private Dictionary<string, ObjectPickup> items;

        public Inventory()
        {
            items = new Dictionary<string, ObjectPickup>(StringComparer.OrdinalIgnoreCase);
        }

        public Inventory(ObjectPickup inventoryItem) : this()
        {
            items.Add(inventoryItem.name, inventoryItem);
        }

        public Inventory(Dictionary<string, ObjectPickup> batch) : this()
        {
            foreach (KeyValuePair<string, ObjectPickup> item in batch)
            {
                items.Add(item.Key, item.Value);
            }
        }

        public bool Add(ObjectPickup itemToAdd)
        {
            if (itemToAdd == null)
            {
                return false;
            }

            items.Add(itemToAdd.name, itemToAdd);

            return true;
        }

        public ObjectPickup Remove(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                return null;
            }

            if (items.Keys.Contains<string>(itemName))
            {
                ObjectPickup removedItem;
                if(items.TryGetValue(itemName, out removedItem))
                {
                    items.Remove(itemName);
                    return removedItem;
                }
            }

            return null;
        }

        public void LogInventory()
        {
            foreach (var item in items)
            {
                Debug.Log("Inventory has " + item.Key);
            }
        }
    }
}
