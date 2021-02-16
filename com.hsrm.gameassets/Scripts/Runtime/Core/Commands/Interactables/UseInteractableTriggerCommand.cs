using HSRM.Core.Interactables;

namespace HSRM.Core.Commands
{
    public class UseInteractableTriggerCommand : BaseUseInteractableCommand
    {
        
        private InteractableTrigger InteractableTrigger => Interactable as InteractableTrigger;

        public override bool CanUseInteractable(BaseInteractable interactable)
        {
            return interactable is InteractableTrigger;
        }

        protected override void ExecuteCommand()
        {
            InteractableTrigger.Trigger();
        }

    }

}