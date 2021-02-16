using HSRM.Core.Interactables;

namespace HSRM.Core.Commands
{
    public class UseInteractableToggleCommand : BaseUseInteractableCommand
    {
        
        private InteractableToggle InteractableToggle => Interactable as InteractableToggle;

        public override bool CanUseInteractable(BaseInteractable interactable)
        {
            return interactable is InteractableToggle;
        }

        protected override void ExecuteCommand()
        {
            InteractableToggle.ToggleValue();
        }

    }

}