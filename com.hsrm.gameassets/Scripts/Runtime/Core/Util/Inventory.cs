using HSRM.Core.Collectables;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core
{
    public class Inventory : MonoBehaviour
    {
        public UnityEvent OnInventoryUpdated = null;
        [SerializeField] private Dictionary<InventoryItem, int> items = new Dictionary<InventoryItem, int>();

        public IEnumerable<KeyValuePair<InventoryItem, int>> Items => items.AsEnumerable();

        public void AddItem(InventoryItem itemType, int amount)
        {
            if (items.ContainsKey(itemType))
            {
                items[itemType] += amount;
            }
            else
            {
                items.Add(itemType, amount);
            }
            OnInventoryUpdated?.Invoke();
        }

        public void RemoveItem(InventoryItem itemType, int amount)
        {
            if (GetItemCount(itemType) >= amount)
            {
                items[itemType] -= amount;
                OnInventoryUpdated?.Invoke();
            }
        }

        public bool ContainsItem(InventoryItem itemType)
        {
            if (items.TryGetValue(itemType, out var amount))
            {
                return amount > 0;
            }
            return false;
        }

        public int GetItemCount(InventoryItem itemType)
        {
            if (items.TryGetValue(itemType, out var amount))
            {
                return amount;
            }
            return 0;
        }
    }
}