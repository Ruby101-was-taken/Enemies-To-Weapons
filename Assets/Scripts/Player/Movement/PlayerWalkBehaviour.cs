using Movememnt;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerWalkBehaviour : MovementBehaviour {

        private Vector2 movement_direction_ = Vector3.zero;

        public void MovementInput(InputAction.CallbackContext context) {
            movement_direction_ = context.ReadValue<Vector2>().normalized;
        }

        // Update is called once per frame
        void FixedUpdate() {
            rb_.MovePosition(rb_.position + (movement_direction_ * Time.fixedDeltaTime * walk_speed_));
        }
    }
}
