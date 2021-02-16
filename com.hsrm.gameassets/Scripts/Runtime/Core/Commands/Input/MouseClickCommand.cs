using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core.Commands
{
    public class MouseClickCommand : BaseCommand
    {
        public UnityEvent OnClick = null;
        private enum Button { Left = 0, Right = 1, Middle = 2 }

        [SerializeField] private Button mouseButton = Button.Left;

        protected override void ExecuteCommand()
        {
            if (Input.GetMouseButtonUp((int)mouseButton))
            {
                OnClick?.Invoke();
            }
        }

        private void Update()
        {
            Execute();        
        }

    }
}