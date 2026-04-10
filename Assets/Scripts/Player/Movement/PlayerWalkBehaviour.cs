using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerWalkBehaviour : MonoBehaviour {

        [SerializeField]
        private float speed_ = 10f;
        [Space]
        [SerializeField]
        private Vector2 bounds_ = new Vector2(9f, 4.5f);

        private Vector3 movement_direction_ = Vector3.zero;

        public void MovementInput(InputAction.CallbackContext context) {
            movement_direction_ = context.ReadValue<Vector2>().normalized;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            transform.position = transform.position + (movement_direction_*Time.deltaTime*speed_);
            if(math.abs(transform.position.x) > bounds_.x) {
                transform.position = new Vector3(bounds_.x * math.sign(transform.position.x), transform.position.y);
            }
            if(math.abs(transform.position.y) > bounds_.y) {
                transform.position = new Vector3(transform.position.x, bounds_.y * math.sign(transform.position.y));
            }
        }
    }
}
