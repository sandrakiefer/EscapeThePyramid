using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core.Commands
{

    public class StartupEventNotifier : MonoBehaviour
    {
        public UnityEvent OnAwake = null;
        public UnityEvent OnStart = null;

        private void Awake()
        {
            OnAwake?.Invoke();
        }

        private void Start()
        {
            OnStart?.Invoke();
        }
    }

}