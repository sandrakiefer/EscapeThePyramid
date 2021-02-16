using UnityEngine;

namespace HSRM.Core.Cameras
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera = null;
        [SerializeField] private bool lockCursor = true;

        public Camera TargetCamera => targetCamera;
        public bool LockCursor 
        { 
            get => lockCursor;
            set
            {
                lockCursor = value;
                UpdateCursorLock();
            }
        }

        public bool IsCurrentCameraControl => isCurrentCameraControl;
        public virtual Vector3 LookPosition { get => targetCamera.transform.position; }
        public virtual Quaternion LookRotation { get => targetCamera.transform.rotation; }

        private bool isCurrentCameraControl = false;

        public virtual void AlignTransform(Vector3 position, Quaternion lookRotation) 
        {
            transform.position = position;
            transform.rotation = lookRotation;
        }

        public void Activate()
        {
            isCurrentCameraControl = true;
            HandleActivated();
        }

        public void Deactivate()
        {
            isCurrentCameraControl = false;
            HandleDeactivated();
        }

        public void ToggleLockCursor()
        {
            lockCursor = !lockCursor;
            UpdateCursorLock();
        }

        protected virtual void UpdateCursorLock()
        {
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                // only hide cursor in editor and if application is running in fullscreen-mode
                if (Application.isEditor || Screen.fullScreen)
                { 
                    Cursor.visible = false;
                }
            }
            else 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        protected virtual void HandleActivated() { }
        protected virtual void HandleDeactivated() { }

        protected virtual void HandleUpdate() { }

        private void Update()
        {
            if (isCurrentCameraControl)
            { 
                HandleUpdate();
                UpdateCursorLock();
            }
        }

    }
}