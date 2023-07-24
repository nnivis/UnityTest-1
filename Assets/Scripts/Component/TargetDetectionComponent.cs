using UnityEngine;

namespace TowerDefence
{
    public class TargetDetectionComponent : MonoBehaviour
    {
        public float _detectionRadius;
        GameObject _currentTarget;
        float _speedLookTraget;

        public void Init(float speedLookTargetData, float detectionRadius)
        {
            _speedLookTraget = speedLookTargetData;
            _detectionRadius = detectionRadius;
        }

        public bool TargetDetection()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    GameObject target = collider.gameObject;

                    if (_currentTarget == null || target != _currentTarget)
                    {
                        _currentTarget = target;
                        LookTarget(_currentTarget);
                        return true;
                    }
                }
            }

            _currentTarget = null;

            return false;
        }

        public GameObject GetCurrentTarget()
        {
            return _currentTarget;
        }

        void LookTarget(GameObject target)
        {
            Vector3 direction = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedLookTraget * Time.deltaTime);
        }
    }
}
