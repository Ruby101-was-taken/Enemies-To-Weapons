using UnityEngine;

namespace Damage {
    public class DealDamageBehaviour : MonoBehaviour {
        [SerializeField]
        private DamageData damage_data_;

        [SerializeField]
        private Transform knockback_source_transform_;

        public Transform Knockback_source_transform_ { get => knockback_source_transform_;  }

        public DamageContext GetDamageContext(Vector3 position) {
            return new DamageContext(damage_data_.strength_, damage_data_.knock_back_power_, (position - knockback_source_transform_.position).normalized);
        }
    }



    public class DamageContext {
        public float damage_;
        public Vector2 knock_back_;

        public DamageContext(float damage, float knock_back, Vector3 forward) {
            damage_ = damage;
            knock_back_ = forward * knock_back;
        }
    }
}