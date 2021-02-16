using UnityEngine;
using HSRM.Core.Events;

namespace HSRM.Core.Interactables
{

    public class InteractableDoor : BaseInteractable
    {
        public enum Interaction { Open, Close, ToggleOpenState }

        public BoolEvent IsOpenChanged = null;

        [SerializeField] private Interaction interactionType = Interaction.ToggleOpenState;
        [SerializeField] private bool isOpen = false;

        public Interaction InteractionType => interactionType;

        public bool IsOpen 
        { 
            get => isOpen;

            protected set 
            {
                if (IsInteractable)
                {
                    isOpen = value;
                    IsOpenChanged?.Invoke(isOpen);
                }
            }
        }

        public void OpenDoor()
        {
            if (!isOpen)
            {
                IsOpen = true;
            }
        }

        public void CloseDoor()
        {
            if (isOpen)
            {
                IsOpen = false;
            }
        }

        public void ToggleDoor()
        {
            IsOpen = !isOpen;
        }
    }
}