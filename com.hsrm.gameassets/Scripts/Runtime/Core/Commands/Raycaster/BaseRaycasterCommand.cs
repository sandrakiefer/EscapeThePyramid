using UnityEngine;

namespace HSRM.Core.Commands
{
    public abstract class BaseRaycasterCommand : BaseCommand
    {
        [SerializeField] private Raycaster raycaster = null;
        [SerializeField] private LayerMask includeLayers = new LayerMask();
        
        [SerializeField] private float maxRaycastDistance = 5f;

        public override bool CanExecute 
        { 
            get => base.CanExecute && raycaster != null && raycaster.HasCamera; 
            set => base.CanExecute = value; 
        }

        protected Ray ray;
        protected Raycaster Raycaster => raycaster;
        protected float MaxRaycastDistance => maxRaycastDistance;

        protected bool HasRaycastHit(out RaycastHit hit)
        {
            ray = raycaster.Camera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            return Physics.Raycast(ray, out hit, maxRaycastDistance, includeLayers);
        }

        protected override void ExecuteCommand()
        {
            if (HasRaycastHit(out var hit))
            {
                HandleHit(hit);
            }
            else 
            {
                HandleMiss();
            }
        }

        protected abstract void HandleHit(RaycastHit hit);
        protected abstract void HandleMiss();

    }
}