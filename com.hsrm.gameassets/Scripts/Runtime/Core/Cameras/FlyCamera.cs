using HSRM.Core.Util;
using UnityEngine;

namespace HSRM.Core.Cameras
{
    [RequireComponent(typeof(CharacterController))]
    public class FlyCamera : CameraControl
    {
        [SerializeField] private bool useCollisionDetection = true;

        [SerializeField] private float speed = 5f;
        [SerializeField] private float fastSpeed = 12f;
        [SerializeField] private float floatFactor = .4f;

        [SerializeField] private MouseLook mouseLook = null;

        private Vector2 currentMoveInput = Vector2.zero;
        private Vector3 currentMovement = Vector3.zero;

        private CharacterController characterController = null;

        public bool UseCollisionDetection { get => useCollisionDetection; set => useCollisionDetection = value; }
        
        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        public override void AlignTransform(Vector3 position, Quaternion lookRotation)
        {
            characterController.enabled = false;
            transform.position = position;
            mouseLook.Initialize(lookRotation);
            characterController.enabled = useCollisionDetection;
        }

        protected override void HandleActivated()
        {
            characterController.enabled = useCollisionDetection;
        }

        protected override void HandleDeactivated()
        {
            characterController.enabled = false;
        }

        protected override void HandleUpdate()
        {
            ApplyLookRotation();
            ReadMovementInput();
            ApplyMovement();
        }

        private void ApplyLookRotation()
        {
            mouseLook.UpdateRotation();
        }

        private void ReadMovementInput()
        {
            float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : speed;
            // get key input
            currentMoveInput.x = Input.GetAxis("Horizontal");
            currentMoveInput.y = Input.GetAxis("Vertical");

            Vector3 moveDelta = Vector3.zero;
            moveDelta = currentMoveInput.x * transform.right;
            moveDelta += currentMoveInput.y * transform.forward;

            // add up/down or floatMovement
            var floatMovement = transform.up * floatFactor;
            if (Input.GetKey(KeyCode.E))
            {
                moveDelta += floatMovement;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                moveDelta -= floatMovement;
            }

            // normalize move delta if needed
            if (moveDelta.magnitude > 1f)
            {
                moveDelta.Normalize();
            }
            // apply move speed factor
            currentMovement = moveDelta * moveSpeed * Time.deltaTime;
        }

        private void ApplyMovement()
        {
            characterController.enabled = useCollisionDetection;
            if (useCollisionDetection)
            {
                characterController.Move(currentMovement);
            }
            else
            {
                transform.position += currentMovement;
            }
        }

    }
}