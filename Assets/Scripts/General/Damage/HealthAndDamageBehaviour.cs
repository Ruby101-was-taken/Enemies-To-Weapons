using System.Collections.Generic;
using Damage;
using UnityEngine;
using Movememnt;
using UnityEngine.Events;

namespace Health {
    public class HealthAndDamageBehaviour : MonoBehaviour {

        [SerializeField]
        private float health_ = 1f;
        [SerializeField]
        private float knockback_multiplier_ = 1f;

        [SerializeField]
        private List<string> damaging_tags_ = new List<string>();
        [SerializeField]
        private List<string> solid_damaging_tags_ = new List<string>();

        [SerializeField]
        private MovementBehaviour movement_;

        [SerializeField]
        private GameObject spawn_on_death_;

        [SerializeField]
        private UnityEvent on_hit_event_;

        [SerializeField]
        private UnityEvent on_death_event_;

        private Rigidbody2D rb_;

        [SerializeField]
        private float spawn_invincibility_time_ = 0.5f;

        private void Awake() {
            rb_ = GetComponent<Rigidbody2D>();
        }

        private bool CanBeHit() {
            return spawn_invincibility_time_ <= 0;
        }

        private void Update() {
            if(spawn_invincibility_time_ > 0)
                spawn_invincibility_time_ -= Time.deltaTime;
        }

        private void OnDeath() {
            on_death_event_.Invoke();
            if(spawn_on_death_ != null)
                Instantiate(spawn_on_death_, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        private void OnHit(DamageContext damage_context) {
            on_hit_event_.Invoke();
            rb_.linearVelocity = damage_context.knock_back_* knockback_multiplier_;
            movement_.StopMoving();
        }

        private void TryHit(Collider2D collision) {
            DealDamageBehaviour damage = collision.gameObject.GetComponent<DealDamageBehaviour>();
            if(damage != null) {
                DoDamage(damage.GetDamageContext(transform.position));
            }
            else {
                DoDamage(new DamageContext(1f, 0f, Vector3.zero));
            }
        }
        private void TryHit(Collision2D collision) {
            DealDamageBehaviour damage = collision.gameObject.GetComponent<DealDamageBehaviour>();
            if(damage != null) {
                DoDamage(damage.GetDamageContext(transform.position));
            }
            else {
                DoDamage(new DamageContext(1f, 0f, Vector3.zero));
            }
        }

        private void DoDamage(DamageContext damage_context) {
            health_ -= damage_context.damage_;
            if(health_ > 0)
                OnHit(damage_context);
            else
                OnDeath();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(CanBeHit()) {
                foreach(string tag in damaging_tags_) {
                    if(collision.CompareTag(tag)) {
                        TryHit(collision);
                        break;
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if(CanBeHit()) {
                foreach(string tag in solid_damaging_tags_) {
                    if(collision.collider.CompareTag(tag)) {
                        TryHit(collision);
                        break;
                    }
                }
            }
        }
    }
}