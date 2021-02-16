using HSRM.Core.Commands;
using System.Collections.Generic;
using UnityEngine;

namespace HSRM.Core
{
    public class Raycaster : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera = null;
        [SerializeField] private GameObject userInterface = null;

        [SerializeField] private MouseClickCommand clickCommand = null;
        
        public bool IsInteractable
        {
            get => clickCommand.CanExecute;
            set
            {
                clickCommand.CanExecute = value;
                SetUserInterfaceVisible(value);
            }
        }

        public bool HasCamera => Camera != null;

        public Camera Camera
        {
            get => targetCamera;
            set => targetCamera = value;
        }

        private void SetUserInterfaceVisible(bool visible)
        {
            userInterface.SetActive(visible);
        }

    }
}