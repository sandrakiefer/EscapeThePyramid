using System.Collections;
using UnityEngine;

namespace HSRM.Core.Commands
{
    public class SetRaycasterInteractableCommand : BaseUndoableCommand
    {
        [SerializeField] private bool interactable = true;

        public override bool CanUndo => canUndo;

        private bool canUndo = false;
        private bool wasInteractable = false;

        protected override void ExecuteCommand()
        {
            var raycaster = FindObjectOfType<Raycaster>();
            if (raycaster != null)
            {
                wasInteractable = raycaster.IsInteractable;
                canUndo = true;

                raycaster.IsInteractable = interactable;
            }
        }

        protected override void UndoCommand()
        {
            var raycaster = FindObjectOfType<Raycaster>();
            if (raycaster != null)
            {
                raycaster.IsInteractable = wasInteractable;
                canUndo = false;
            }
        }

    }
}