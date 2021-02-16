using UnityEngine;
using HSRM.Core.Events;

namespace HSRM.Core.Util
{
    public class TriggerEventNotifier : MonoBehaviour
    {
        public ColliderEvent OnEnter = null;
        public ColliderEvent OnExit = null;
        public ColliderEvent OnStay = null;

        private void OnTriggerEnter(Collider other)
        {
            OnEnter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnExit?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnStay?.Invoke(other);
        }
    }
}