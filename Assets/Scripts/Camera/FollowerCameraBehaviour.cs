using UnityEngine;

namespace Player_Camera {
    public class FollowerCameraBehaviour : MonoBehaviour {

        [SerializeField]
        private GameObject follow_target_;

        [SerializeField]
        private float max_x_distance_ = 15f;


        // Update is called once per frame
        void Update() {
            Vector3 target_pos = follow_target_.transform.position;
            Vector3 target_camera_pos = new Vector3(target_pos.x, target_pos.y, -10);
            transform.position = Vector3.Lerp(transform.position, target_camera_pos, Time.deltaTime*3);
            if(transform.position.x > max_x_distance_)
                transform.position = new Vector3(max_x_distance_, transform.position.y, transform.position.z);
            
        }
    }
}