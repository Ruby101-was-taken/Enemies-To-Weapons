using System.Collections;
using Damage;
using UnityEngine;

namespace Enemy {
    public class KickableEnemyMovementBehaviour : BaseEnemyMovementBehaviour {

        [SerializeField]
        private CircleCollider2D collider_;
        [SerializeField]
        private float knockback_multiplier_;

        private IEnumerator EnableCollider() {
            yield return new WaitForSeconds(0.1f);
            collider_.enabled = true;
        }

        protected override void Awake() {
            base.Awake();
            collider_.enabled = false;
            StartCoroutine(EnableCollider());
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.CompareTag("PlayerAttack")) {
                rb_.linearVelocity = (transform.position - collision.GetComponent<DealDamageBehaviour>().Knockback_source_transform_.position).normalized * knockback_multiplier_;
                StopMoving();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if(collision.collider.CompareTag("Wall")) {
                Destroy(gameObject);
            }
        }
    }
}
