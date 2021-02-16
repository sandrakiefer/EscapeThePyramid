using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core.Cameras
{

    public class CameraController : MonoBehaviour
    {
        public UnityEvent OnCameraControlActivated = null;

        [SerializeField] private CameraControl currentCameraControl = null;
        [SerializeField] private bool initializeOnStart = true;

        public CameraControl CurrentCameraControl 
        { 
            get => currentCameraControl; 
            private set { currentCameraControl = value; } 
        }

        private void Start()
        {
            if (initializeOnStart)
            { 
                DeactivateSceneCameraControls();
                if (HasCurrentCameraControl)
                {
                    CurrentCameraControl.gameObject.SetActive(true);
                    CurrentCameraControl.Activate();
                    OnCameraControlActivated?.Invoke();
                }
            }
        }

        public bool HasCurrentCameraControl => CurrentCameraControl != null;

        public void DeactivateSceneCameraControls()
        {
            var cameraControls = FindObjectsOfType<CameraControl>();
            foreach (var cameraControl in cameraControls)
            {
                if (cameraControl.IsCurrentCameraControl)
                { 
                    cameraControl.Deactivate();
                }
                cameraControl.gameObject.SetActive(false);
            }
        }

        public void ActivateCameraControl(CameraControl cameraControl)
        {
            DeactivateCurrentCameraControl();
            
            cameraControl.gameObject.SetActive(true);
            cameraControl.Activate();
            if (HasCurrentCameraControl)
            {
                cameraControl.AlignTransform(CurrentCameraControl.LookPosition, CurrentCameraControl.LookRotation);
            }

            CurrentCameraControl = cameraControl;

            OnCameraControlActivated?.Invoke();
        }

        private void DeactivateCurrentCameraControl()
        {
            if (HasCurrentCameraControl)
            {
                CurrentCameraControl.Deactivate();
                CurrentCameraControl.gameObject.SetActive(false);
            }
        }

    }

}