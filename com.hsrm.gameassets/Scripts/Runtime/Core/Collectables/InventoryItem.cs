using UnityEngine;

namespace HSRM.Core.Collectables
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/Inventory Item", order = 1)]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private string itemName = string.Empty;

        public string ItemName => itemName;
    }
}