using UnityEngine;

namespace Enemy {
    public class SlugMovementBehaviour : BaseEnemyMovementBehaviour {

        [SerializeField]
        private GameObject sprite_;

        [SerializeField]
        private float slide_scale_ = 5;

        private float initial_walk_speed_ = 0f;

        protected override void Awake() {
            base.Awake();
            initial_walk_speed_ = walk_speed_;
        }

        private void Update() {
            float time = Time.timeSinceLevelLoad * slide_scale_;
            float scale = Mathf.Max((Mathf.Sin(time) + Mathf.Cos(time)), 0);
            walk_speed_ = scale * initial_walk_speed_;
            sprite_.transform.localScale = new Vector3(1 + (scale*0.25f), 1 - (scale * 0.1f));
        }
    }
}