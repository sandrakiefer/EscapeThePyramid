using HSRM.Core.Collectables;
using HSRM.Core.Util;
using UnityEngine;

namespace HSRM.Core.Commands
{
    public class AddItemToPlayerInventoryCommand : BaseCommand
    {
        [SerializeField] private InventoryItem inventoryItem = null;
        [SerializeField] private int amount = 1;

        public override bool CanExecute 
        {
            get => base.CanExecute && inventoryItem != null; 
            set => base.CanExecute = value; 
        }

        protected override void ExecuteCommand()
        {
            var playerInventory = FindObjectOfType<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(inventoryItem, amount);
            }
            else 
            {
                Debug.LogError("PlayerInventory could not be found. Add item to player inventory failed.", gameObject);
            }
        }

    }
}
