using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core.Commands
{
    public class KeyDownCommand : BaseCommand
    {
        public UnityEvent OnKeyDown = null;

        [SerializeField] private KeyCode keyCode = KeyCode.Space;

        protected override void ExecuteCommand()
        {
            if (Input.GetKeyDown(keyCode))
            {
                OnKeyDown?.Invoke();
            }
        }

        private void Update()
        {
            Execute();
        }

    }
}