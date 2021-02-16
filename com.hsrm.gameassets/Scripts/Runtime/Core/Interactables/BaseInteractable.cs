using UnityEngine;

namespace HSRM.Core.Interactables
{
    public abstract class BaseInteractable : MonoBehaviour
    {
        [SerializeField] private bool isInteractable = true;

        public bool IsInteractable { get => isInteractable; set => isInteractable = value; }

    }
}