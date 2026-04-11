using Movememnt;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerWalkBehaviour : MovementBehaviour {

        private Vector2 movement_direction_ = Vector3.zero;

        [SerializeField]
        private float dash_power_;
        private float dash_cooldown_;

        public void MovementInput(InputAction.CallbackContext context) {
            movement_direction_ = context.ReadValue<Vector2>().normalized;
        }
        public void DashInput(InputAction.CallbackContext context) {
            if(context.started) {
                can_move_ = false;
                rb_.linearVelocity = movement_direction_ * dash_power_;
                dash_cooldown_ = 0.4f;
                
            }
        }

        // Update is called once per frame
        void FixedUpdate() {
            if(can_move_)
                rb_.MovePosition(rb_.position + (movement_direction_ * Time.fixedDeltaTime * walk_speed_));

            if(dash_cooldown_ > 0f) {
                dash_cooldown_ -= Time.fixedDeltaTime;
                if(dash_cooldown_ <= 0f) {
                    can_move_ = true;
                }
            }
        }
    }
}
