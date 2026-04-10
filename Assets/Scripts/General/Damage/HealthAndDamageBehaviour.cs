using System.Collections.Generic;
using Damage;
using UnityEngine;
using Movememnt;

namespace Health {
    public class HealthAndDamageBehaviour : MonoBehaviour {

        [SerializeField]
        private float health_ = 1f;

        [SerializeField]
        private List<string> damaging_tags_ = new List<string>();

        [SerializeField]
        private MovementBehaviour movement_;

        private Rigidbody2D rb_;

        private void Awake() {
            rb_ = GetComponent<Rigidbody2D>();
        }

        private void OnDeath() {
            Destroy(gameObject);
        }

        private void OnHit(DamageContext damage_context) {
            rb_.linearVelocity = damage_context.knock_back_;
            movement_.StopMoving();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            foreach(string tag in damaging_tags_) {
                if(collision.CompareTag(tag)) {
                    DealDamageBehaviour damage = collision.gameObject.GetComponent<DealDamageBehaviour>();
                    if(damage != null) {
                        DamageContext damage_context= damage.GetDamageContext(transform.position);
                        health_ -= damage_context.damage_;
                        if(health_ > 0)
                            OnHit(damage_context);
                        else
                            OnDeath();
                    }
                }
            }
        }
    }
}