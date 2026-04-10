using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerCombatBehaviour : MonoBehaviour {

        private Camera camera_;
        [SerializeField]
        private float sword_speed_ = 1f;

        private void Awake() {
            camera_ = Camera.main;
        }

        // Update is called once per frame
        void Update() {
            LookAtCamera();    
        }

        void LookAtCamera() {
            Vector3 mouse_screen = Input.mousePosition;
            Vector3 mouse_world_pos = camera_.ScreenToWorldPoint(mouse_screen);

            Vector2 look_direction = mouse_world_pos - transform.position;
            float angle = Mathf.Atan2(look_direction.y, look_direction.x) * Mathf.Rad2Deg - 90f;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * sword_speed_);
        }
    }
}