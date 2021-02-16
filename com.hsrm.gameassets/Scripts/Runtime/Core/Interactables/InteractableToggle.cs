using UnityEngine;
using HSRM.Core.Events;

namespace HSRM.Core.Interactables
{
    public class InteractableToggle : BaseInteractable
    {
        public BoolEvent OnValueChanged = null;

        [SerializeField] private bool boolValue = false;

        public bool BoolValue 
        { 
            get => boolValue;

            set
            {
                if (IsInteractable)
                {
                    boolValue = value;
                    TriggerStateChanged();
                }
            }
        }

        public void ToggleValue()
        {
            BoolValue = !boolValue;
        }

        private void TriggerStateChanged()
        {
            OnValueChanged?.Invoke(boolValue);
        }

    }
}