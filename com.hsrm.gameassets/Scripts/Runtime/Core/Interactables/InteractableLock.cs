using HSRM.Core.Collectables;
using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core.Interactables
{
    public class InteractableLock : BaseInteractable
    {
        public enum Interaction { Lock, Unlock, ToggleLockedState }

        public UnityEvent OnLock;
        public UnityEvent OnUnlock;

        [SerializeField] private Interaction interactionType = Interaction.Unlock;
        [SerializeField] private bool isLocked = true;
        [SerializeField] private InventoryItem unlockItem = null;

        public bool IsLocked { get => isLocked; private set => isLocked = value; }

        public InventoryItem UnlockItem => unlockItem;
        public Interaction InteractionType => interactionType;

        public void Lock()
        {
            if (IsInteractable && !IsLocked)
            {
                OnLock?.Invoke();
            }
            IsLocked = true;
        }

        public void Unlock()
        {
            if (IsInteractable && IsLocked)
            {
                OnUnlock?.Invoke();
            }
            IsLocked = false;
        }
    }
}