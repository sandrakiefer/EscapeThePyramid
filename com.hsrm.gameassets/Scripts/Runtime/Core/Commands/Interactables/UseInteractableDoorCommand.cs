using HSRM.Core.Interactables;

namespace HSRM.Core.Commands
{
    public class UseInteractableDoorCommand : BaseUseInteractableCommand
    {
        public override bool CanUseInteractable(BaseInteractable interactable)
        {
            return interactable is InteractableDoor;
        }

        private InteractableDoor InteractableDoor => Interactable as InteractableDoor;

        protected override void ExecuteCommand()
        {
            switch (InteractableDoor.InteractionType)
            {
                case InteractableDoor.Interaction.Open:
                    InteractableDoor.OpenDoor();
                    break;
                case InteractableDoor.Interaction.Close:
                    InteractableDoor.CloseDoor();
                    break;
                case InteractableDoor.Interaction.ToggleOpenState:
                    InteractableDoor.ToggleDoor();
                    break;
            }
        }
    }
}