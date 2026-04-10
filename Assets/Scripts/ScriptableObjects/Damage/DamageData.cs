using UnityEngine;

namespace Damage {
    [CreateAssetMenu(fileName = "DamageData", menuName = "RightBackAtYa/Combat/DamageData")]
    public class DamageData : ScriptableObject {
        public float strength_;
        public float knock_back_power_;
    }
}