using HSRM.Core.Collectables;
using UnityEngine;

namespace HSRM.Core.Commands
{
    public class AddItemToInventoryCommand : BaseCommand
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private InventoryItem inventoryItem = null;
        [SerializeField] private int amount = 1;

        public override bool CanExecute 
        {
            get => base.CanExecute && inventory != null && inventoryItem != null; 
            set => base.CanExecute = value; 
        }

        protected override void ExecuteCommand()
        {
            inventory.AddItem(inventoryItem, amount);
        }

    }
}