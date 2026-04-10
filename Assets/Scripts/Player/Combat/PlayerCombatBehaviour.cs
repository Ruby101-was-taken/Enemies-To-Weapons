using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerCombatBehaviour : MonoBehaviour {

        [SerializeField]
        private float sword_speed_ = 1f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            Vector3 mouse_screen = Input.mousePosition;
            Vector3 mouse_world_pos = Camera.main.ScreenToWorldPoint(mouse_screen);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(mouse_world_pos.y - transform.position.y, mouse_world_pos.x - transform.position.x) * Mathf.Rad2Deg - 90), Time.deltaTime*sword_speed_);
        }
    }
}