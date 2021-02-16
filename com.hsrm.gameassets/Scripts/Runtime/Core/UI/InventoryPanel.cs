using UnityEngine;

namespace HSRM.Core.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private Inventory targetInventory = null;
        [SerializeField] private Transform listRoot = null;
        [SerializeField] private InventoryItemLabel itemPrefab = null;

        private void Start()
        {
            HandleInventoryUpdated();
            targetInventory.OnInventoryUpdated.AddListener(HandleInventoryUpdated);
        }

        private void OnDestroy()
        {
            targetInventory.OnInventoryUpdated.RemoveListener(HandleInventoryUpdated);
        }

        private void HandleInventoryUpdated()
        {
            ClearList();
            CreateList();
        }

        private void CreateList()
        {
            var numItems = 0;
            foreach (var item in targetInventory.Items)
            {
                // create prefab instance and get inventory label component
                var itemGO = Instantiate(itemPrefab.gameObject, listRoot);
                var inventoryItemLabel = itemGO.GetComponent<InventoryItemLabel>();
                // update label values
                var itemName = item.Key.ItemName;
                var itemAmount = item.Value;
                inventoryItemLabel.UpdateLabel(itemName, itemAmount);
                numItems++;
            }
            UpdateListRootVisibility(numItems > 0);
        }

        private void ClearList()
        {
            for (int i = listRoot.childCount - 1; i >= 0; i--)
            {
                Destroy(listRoot.GetChild(i).gameObject);
            }
        }

        private void UpdateListRootVisibility(bool visible)
        {
            listRoot.gameObject.SetActive(visible);
        }
    }
}