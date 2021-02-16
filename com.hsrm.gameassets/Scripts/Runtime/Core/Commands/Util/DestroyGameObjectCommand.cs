using UnityEngine;

namespace HSRM.Core.Commands
{

    public class DestroyGameObjectCommand : BaseCommand
    {
        [SerializeField] private GameObject target = null;

        public override bool CanExecute 
        { 
            get => base.CanExecute && target != null; 
            set => base.CanExecute = value; 
        }

        protected override void ExecuteCommand()
        {
            Destroy(target);
        }

    }
}
