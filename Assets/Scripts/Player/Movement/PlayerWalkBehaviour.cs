using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerWalkBehaviour : MonoBehaviour {

        [SerializeField]
        private float speed_ = 10f;

        private Vector2 movement_direction_ = Vector3.zero;

        private Rigidbody2D rb_;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake() {
            rb_ = GetComponent<Rigidbody2D>();
        }

        public void MovementInput(InputAction.CallbackContext context) {
            movement_direction_ = context.ReadValue<Vector2>().normalized;
        }

        // Update is called once per frame
        void FixedUpdate() {
            rb_.MovePosition(rb_.position + (movement_direction_ * Time.fixedDeltaTime * speed_));
        }
    }
}
