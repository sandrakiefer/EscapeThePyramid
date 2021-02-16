using HSRM.Core.Interactables;
using UnityEngine;
namespace HSRM.Core.Util
{

    public class InteractableSelector : MonoBehaviour
    {
        [SerializeField] private BaseInteractable interactable = null;

        public BaseInteractable Interactable => interactable;

        private void Awake()
        {
            if (interactable == null) 
            { 
                interactable = transform.GetComponentInParent<BaseInteractable>();
            }
        }
    }

}