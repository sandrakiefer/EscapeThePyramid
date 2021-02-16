using UnityEngine.Events;

namespace HSRM.Core.Interactables
{
    public class InteractableTrigger : BaseInteractable
    {
        public UnityEvent OnTrigger = null;

        public void Trigger()
        {
            if (IsInteractable)
            {
                OnTrigger?.Invoke();
            }
        }

    }
}