using UnityEngine.Events;

namespace HSRM.Core.Commands
{
    public class SimpleCommand : BaseCommand
    {
        public UnityEvent OnExecute = null;
        protected override void ExecuteCommand()
        {
            OnExecute?.Invoke();
        }
    }
}
