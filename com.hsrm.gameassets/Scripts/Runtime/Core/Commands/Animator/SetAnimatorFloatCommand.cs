using UnityEngine;
using HSRM.Core.Events;

namespace HSRM.Core.Commands
{
    public class SetAnimatorFloatCommand : BaseSetAnimatorCommand
    {
        public FloatEvent OnExecute = null;

        [SerializeField] private float floatValue = 0f;

        public float FloatValue { get => floatValue; set => floatValue = value; }

        protected override void ExecuteCommand()
        {
            animator.SetFloat(parameterName, FloatValue);
            OnExecute?.Invoke(FloatValue);
        }
    }
}
