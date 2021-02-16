using HSRM.Core.Cameras;

namespace HSRM.Core.Commands
{
    public class ActivateUICameraControlCommand : BaseUndoableCommand
    {
        private CameraControl prevCameraControl = null;

        public override bool CanUndo
        {
            get => prevCameraControl != null;
        }

        protected override void ExecuteCommand()
        {
            var cameraController = FindObjectOfType<CameraController>();
            if (cameraController != null)
            {
                if (cameraController.CurrentCameraControl is UICameraControl)
                {
                    return;
                }

                var uiCameraControl = cameraController.GetComponentInChildren<UICameraControl>(true);
                if (uiCameraControl != null)
                {
                    prevCameraControl = cameraController.CurrentCameraControl;
                    cameraController.ActivateCameraControl(uiCameraControl);
                }
            }
        }

        protected override void UndoCommand()
        {
            var cameraController = FindObjectOfType<CameraController>();
            if (cameraController != null)
            {
                if (cameraController.CurrentCameraControl != prevCameraControl)
                {
                    cameraController.ActivateCameraControl(prevCameraControl);
                    prevCameraControl = null;
                }
            }
        }
    }
}