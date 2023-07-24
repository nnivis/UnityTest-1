using UnityEngine;


namespace TowerDefence
{
    [CreateAssetMenu(fileName = "New TowerData", menuName = "Tower Data")]

    public class CannonTowerData : ScriptableObject
    {
        public float speedLookTargetData;
        public float detectionRadius;
        public float shootInterval;
        public float shootSpeed;
    }
}