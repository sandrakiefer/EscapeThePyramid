using HSRM.Core.Interactables;
using HSRM.Core.Util;
using UnityEngine;
using UnityEngine.Events;
using HSRM.Core.Events;

namespace HSRM.Core.Commands
{
    public class SelectInteractableCommand : BaseSelectionCommand
    {
        public InteractableEvent OnInteractableSelected = null;
        public UnityEvent OnSelectionFailed = null;

        protected override void HandleHit(RaycastHit hit)
        {
            Transform hitTransform = hit.transform;
            if (hitTransform.TryGetComponent<BaseInteractable>(out var interactable))
            {
                HandleInteractable(interactable);
            }
            else if (hitTransform.TryGetComponent<InteractableSelector>(out var selector))
            {
                HandleInteractable(selector.Interactable);
            }
            else 
            {
                HandleMiss();
            }
        }

        protected override void HandleMiss()
        {
            HasSelection = false;
            OnSelectionFailed?.Invoke();
        }

        private void HandleInteractable(BaseInteractable interactable)
        {
            HasSelection = true;
            OnInteractableSelected?.Invoke(interactable);
        }
    }
}