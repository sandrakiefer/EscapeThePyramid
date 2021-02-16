using HSRM.Core.Collectables;
using HSRM.Core.Interactables;
using HSRM.Core.Util;
using UnityEngine;
using UnityEngine.UI;

namespace HSRM.Core.Commands
{
    public class UpdateRaycasterCursorCommand : BaseRaycasterCommand
    {
        [SerializeField] private Image indicatorImage = null;

        [SerializeField] private Color isInteractableColor = Color.yellow;
        [SerializeField] private Color notInteractableColor = Color.red;
        [SerializeField] private Color isCollectableColor = Color.green;
        [SerializeField] private Color defaultColor = Color.white;

        private void Update()
        {
            Execute();
        }

        protected override void HandleHit(RaycastHit hit)
        {
            Transform hitTransform = hit.transform;
            if (hitTransform.TryGetComponent<Collectable>(out var collectable))
            {
                DrawDebugRay(hit.distance, isCollectableColor);
                UpdateCursor(isCollectableColor);
            }
            else if (hitTransform.TryGetComponent<BaseInteractable>(out var interactable))
            {
                HandleInteractable(hit, interactable);
            }
            else if (hitTransform.TryGetComponent<InteractableSelector>(out var interactableSelector))
            {
                HandleInteractable(hit, interactableSelector.Interactable);
            }
            else
            {
                DrawDebugRay(hit.distance, defaultColor);
                UpdateCursor(defaultColor);
            }
        }

        private void HandleInteractable(RaycastHit hit, BaseInteractable interactable)
        {
            if (interactable.IsInteractable)
            {
                DrawDebugRay(hit.distance, isInteractableColor);
                UpdateCursor(isInteractableColor);
            }
            else
            {
                DrawDebugRay(hit.distance, notInteractableColor);
                UpdateCursor(notInteractableColor);
            }
        }

        protected override void HandleMiss()
        {
            DrawDebugRay(MaxRaycastDistance, defaultColor);
            UpdateCursor(defaultColor);
        }

        private void DrawDebugRay(float distance, Color color)
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, color);
        }

        protected void UpdateCursor(Color color)
        {
            indicatorImage.color = color;
        }
    }
}