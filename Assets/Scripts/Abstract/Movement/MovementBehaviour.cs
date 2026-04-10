using System.Collections;
using UnityEngine;

namespace Movememnt {
    public class MovementBehaviour : MonoBehaviour, ICanStopMoving {

        private bool can_move_ = true;

        public bool Can_move_ { get => can_move_; }

        public void StartMoving() {
            can_move_ = true;
        }
        public void StopMoving() {
            can_move_ = false;
            StartCoroutine(WaitToStartMoving());
        }

        private IEnumerator WaitToStartMoving() {
            yield return new WaitForSeconds(0.25f);
            StartMoving();
        }

        [SerializeField]
        protected float walk_speed_;

        protected Rigidbody2D rb_;

        private void Awake() {
            rb_ = GetComponent<Rigidbody2D>();
        }
    }
}