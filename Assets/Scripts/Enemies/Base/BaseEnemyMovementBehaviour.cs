using Movememnt;
using UnityEngine;

namespace Enemy {
    public class BaseEnemyMovementBehaviour : MovementBehaviour {



        // Update is called once per frame
        void FixedUpdate() {
            if(Can_move_) {
                rb_.MovePosition(rb_.position - new Vector2(walk_speed_ * Time.fixedDeltaTime, 0));
            }
        }
    }
}