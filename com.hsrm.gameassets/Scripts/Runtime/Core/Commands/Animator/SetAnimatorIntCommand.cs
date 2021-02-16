using UnityEngine;
using HSRM.Core.Events;

namespace HSRM.Core.Commands
{
    public class SetAnimatorIntCommand : BaseSetAnimatorCommand
    {
        public IntEvent OnExecute = null;

        [SerializeField] private int intValue = 0;

        public int IntValue { get => intValue; set => intValue = value; }

        protected override void ExecuteCommand()
        {
            animator.SetInteger(parameterName, IntValue);
            OnExecute?.Invoke(IntValue);
        }
    }
}
