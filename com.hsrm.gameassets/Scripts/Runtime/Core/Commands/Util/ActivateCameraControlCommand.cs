using HSRM.Core.Cameras;
using UnityEngine;

namespace HSRM.Core.Commands
{
    public class ActivateCameraControlCommand : BaseUndoableCommand
    {
        [SerializeField] private CameraController cameraController = null;
        [SerializeField] private CameraControl cameraControl = null;

        private CameraControl prevCameraControl = null;

        public override bool CanExecute 
        { 
            get => base.CanExecute && cameraController != null && cameraControl != null; 
        }

        public override bool CanUndo
        {
            get => prevCameraControl != null;
        }

        protected override void ExecuteCommand()
        {
            if (cameraController.CurrentCameraControl != cameraControl)
            { 
                prevCameraControl = cameraController.CurrentCameraControl;
                cameraController.ActivateCameraControl(cameraControl);
            }
        }

        protected override void UndoCommand()
        {
            if (cameraController.CurrentCameraControl != prevCameraControl)
            { 
                cameraController.ActivateCameraControl(prevCameraControl);
                prevCameraControl = null;
            }
        }
    }
}