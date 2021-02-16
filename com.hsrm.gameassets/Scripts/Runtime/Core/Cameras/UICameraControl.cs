using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core.Cameras
{
    public class UICameraControl : CameraControl
    {
        public UnityEvent OnActivated = null;
        public UnityEvent OnDeactivated = null;

        protected override void UpdateCursorLock()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        protected override void HandleActivated()
        {
            OnActivated?.Invoke();
        }

        protected override void HandleDeactivated()
        {
            OnDeactivated?.Invoke();
        }

    }
}