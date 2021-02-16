using HSRM.Core.Util;
using UnityEngine;

namespace HSRM.Core.Cameras
{
    [RequireComponent(typeof(CharacterController))]
    public class WalkCameraControl : CameraControl
    {
        [SerializeField] private Transform headTransform = null;

        [SerializeField] private float speed = 5f;
        [SerializeField] private float fastSpeed = 12f;
        [SerializeField] private float stickToGroundForce = 0f;
        [SerializeField] private float gravityMultiplier = 0f;
        [SerializeField] private float pushForce = 5f;

        [SerializeField] private MouseLook transformMouseLook = null;
        [SerializeField] private MouseLook headMouseLook = null;

        private Vector2 currentMoveInput = Vector2.zero;
        private Vector3 currentMovement = Vector3.zero;
        private float currentMoveSpeed = 0f;

        private CharacterController characterController = null;

        private CollisionFlags collisionFlags = CollisionFlags.None;

        private Vector3 HeadOffset => headTransform.position - transform.position;

        public override Vector3 LookPosition => headTransform.position;
        public override Quaternion LookRotation => Quaternion.Euler(headTransform.eulerAngles.x, transform.eulerAngles.y, 0);

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        public override void AlignTransform(Vector3 position, Quaternion lookRotation)
        {
            // disable character controller and set transform position
            characterController.enabled = false;
            transform.position = position - HeadOffset;

            // apply transform roation
            var transformRotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            transformMouseLook.Initialize(transformRotation);

            // apply head transform rotation
            var headRotation = Quaternion.Euler(lookRotation.eulerAngles.x, 0f, 0f);
            headMouseLook.Initialize(headRotation);
            
            // enable character controller
            characterController.enabled = true;
        }

        protected override void HandleActivated()
        {
            characterController.enabled = true;
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
            transformMouseLook.UpdateRotation();
            headMouseLook.UpdateRotation();
        }

        private void ReadMovementInput()
        {
            currentMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : speed;
            // get key input
            currentMoveInput.x = Input.GetAxis("Horizontal");
            currentMoveInput.y = Input.GetAxis("Vertical");

            // normalize move delta if needed
            if (currentMoveInput.magnitude > 1f)
            {
                currentMoveInput.Normalize();
            }
        }

        private void ApplyMovement()
        {
            // calculate local move delta by current input
            Vector3 moveDelta = Vector3.zero;
            moveDelta = currentMoveInput.x * transform.right;
            moveDelta += currentMoveInput.y * transform.forward;

            // apply move speed factor to x-z move delta
            currentMovement.x = moveDelta.x * currentMoveSpeed;
            currentMovement.z = moveDelta.z * currentMoveSpeed;
            
            // apply y-movement depending on grounded state
            if (characterController.isGrounded)
            {
                currentMovement.y = -stickToGroundForce;
            }
            else
            {
                currentMovement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
            }
            
            // move character controller and store collision flags for further processing in OnControllerColliderHit
            collisionFlags = characterController.Move(currentMovement * Time.deltaTime);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.yellow);
            // ignore collisions below
            if (collisionFlags == CollisionFlags.Below)
            {
                return;
            }
            // ignore collisions with static colliders or kinematic rigibodies
            Rigidbody body = hit.collider.attachedRigidbody;
            if (body == null || body.isKinematic)
            {
                return;
            }
            // add push force to rigidbody
            var force = hit.moveDirection * pushForce * characterController.velocity.magnitude / body.mass;
            body.AddForceAtPosition(force, hit.point, ForceMode.Impulse);
        }
    }

}