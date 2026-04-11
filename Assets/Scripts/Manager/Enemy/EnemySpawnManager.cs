using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class EnemySpawnManager : MonoBehaviour {

        [SerializeField]
        private float vertical_bounds_ = 11f;

        [SerializeField]
        private List<GameObject> spawnable_enemies_ = new List<GameObject>();

        private bool can_spawn_ = true;

        private IEnumerator SpawnEnemy(int enemies_to_spawn) {
            can_spawn_ = false;
            for(int i = 0; i < enemies_to_spawn; i++) {
                transform.position = new Vector3(transform.position.x, Random.Range(-vertical_bounds_, vertical_bounds_));
                Instantiate(spawnable_enemies_[Random.Range(0, spawnable_enemies_.Count)], transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(10f);
            can_spawn_ = true;
        }

        private void FixedUpdate() {
            if(can_spawn_)
                StartCoroutine(SpawnEnemy(3));
        }
    }
}