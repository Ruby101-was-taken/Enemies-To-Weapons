using System.Collections;
using UnityEngine;

namespace Enemy {
    public class KickableEnemyMovementBehaviour : BaseEnemyMovementBehaviour {

        [SerializeField]
        private CircleCollider2D collider_;

        private IEnumerator EnableCollider() {
            yield return new WaitForSeconds(0.1f);
            collider_.enabled = true;
        }

        protected override void Awake() {
            base.Awake();
            collider_.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }
}
