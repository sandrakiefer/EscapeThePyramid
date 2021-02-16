using HSRM.Core.Interactables;
using UnityEngine;

namespace HSRM.Core.Commands
{
    public class UseInteractableLockCommand : BaseUseInteractableCommand
    {
        [SerializeField] private Inventory inventory = null;

        private bool HasInventory => inventory != null;
        private InteractableLock InteractableLock => Interactable as InteractableLock;

        public override bool CanExecute 
        { 
            get => base.CanExecute && HasInventory; 
            set => base.CanExecute = value; 
        }

        public override bool CanUseInteractable(BaseInteractable interactable)
        {
            return interactable is InteractableLock;
        }

        protected override void ExecuteCommand()
        {
            switch (InteractableLock.InteractionType)
            {
                case InteractableLock.Interaction.Lock:
                    LockInteractable();
                    break;

                case InteractableLock.Interaction.Unlock:
                    UnlockInteractable();
                    break;

                case InteractableLock.Interaction.ToggleLockedState:
                    if (InteractableLock.IsLocked)
                    {
                        UnlockInteractable();
                    }
                    else
                    {
                        LockInteractable();
                    }
                    break;
            }
        }

        private void UnlockInteractable()
        {
            if (inventory.ContainsItem(InteractableLock.UnlockItem))
            {
                InteractableLock.Unlock();
            }
        }

        private void LockInteractable()
        {
            if (inventory.ContainsItem(InteractableLock.UnlockItem))
            {
                InteractableLock.Lock();
            }
        }
    }
}