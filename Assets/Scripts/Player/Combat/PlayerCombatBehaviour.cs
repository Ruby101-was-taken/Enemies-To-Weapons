using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

namespace Player {
    public class PlayerCombatBehaviour : MonoBehaviour {

        private Camera camera_;
        [SerializeField]
        private float sword_speed_ = 1f;

        private bool face_mouse_ = true;

        [SerializeField]
        private float attack_angle_change_ = 10f;
        private float rotation_at_start_of_attack_ = 0f;

        [SerializeField]
        private BoxCollider2D hit_box_;

        [SerializeField]
        private float swing_speed_ = 2f;
        private float swing_time_ = 1f;
        private float swing_timer_ = 0f;

        private void Awake() {
            camera_ = Camera.main;
        }

        // Update is called once per frame
        void Update() {
            if(face_mouse_) {
                LookAtCamera(true);
            }
            else {
                Attack();
            }
        }

        void LookAtCamera(bool lerp) {
            Vector3 mouse_screen = Input.mousePosition;
            Vector3 mouse_world_pos = camera_.ScreenToWorldPoint(mouse_screen);

            Vector2 look_direction = mouse_world_pos - transform.position;
            float angle = Mathf.Atan2(look_direction.y, look_direction.x) * Mathf.Rad2Deg - 90f;

            if(lerp)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * sword_speed_);
            else
                transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        void FinishAttack() {
            face_mouse_ = true;
            hit_box_.enabled = false;
        }

        void Attack() {
            transform.rotation = Quaternion.Euler(0, 0, rotation_at_start_of_attack_ + ((attack_angle_change_*2)*swing_timer_)-attack_angle_change_);
            //FinishAttack();
            swing_timer_ -= Time.deltaTime*swing_speed_;
            if(swing_timer_ <= 0)
                FinishAttack();
        }

        public void BeginAttack(InputAction.CallbackContext context) {
            if(context.started && face_mouse_) {
                LookAtCamera(false);
                face_mouse_ = false;

                //transform.DORotate(new Vector3(0, 0, rotation_at_start_of_attack_ + attack_angle_change_), 0.2f).SetEase(Ease.OutSine).onComplete = FinishAttack;
                hit_box_.enabled = true;
                rotation_at_start_of_attack_ = transform.eulerAngles.z;
                transform.rotation = Quaternion.Euler(0, 0, rotation_at_start_of_attack_ - attack_angle_change_);
                swing_timer_ = swing_time_;

            }
        }
    }
}