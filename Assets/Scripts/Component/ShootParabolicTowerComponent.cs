using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence

{
    public class ShootParabolicTowerComponent : ShooterBase
    {
       bool _shootBool = true;
        float _shootInterval;
        float _shootSpeed;
        [SerializeField] GameObject _projectilePrefab;
        [SerializeField] Transform _shootPoint;
        TargetDetectionComponent _targetDetectionComponent;

        public void Init(float shootInterval, float shootSpeed)
        {
            _shootInterval = shootInterval;
            _shootSpeed = shootSpeed;
        }

        void Start()
        {
            
            _targetDetectionComponent = GetComponent<TargetDetectionComponent>();
        }

        public override void Shoot()
        {
            StartCoroutine(CoolDown());
        }

        IEnumerator CoolDown()
        {
            while (_shootBool)
            {
                _shootBool = false;

                GameObject projectile = Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);
                Projectile projectileScript = projectile.GetComponent<Projectile>();

                GameObject currentTarget = _targetDetectionComponent.GetCurrentTarget();

                if (currentTarget != null)
                {
                    Vector3 targetPosition = currentTarget.transform.position;
                    Vector3 direction = (targetPosition - _shootPoint.position).normalized;

                    float timeToTarget = Vector3.Distance(targetPosition, _shootPoint.position) / _shootSpeed;
                    float yOffset = 0.5f * 0.1f * Mathf.Pow(timeToTarget, 2);
                    Vector3 parabolicDirection = direction + Vector3.up * yOffset;
                    
                    projectileScript.SetInitialDirection(parabolicDirection * _shootSpeed);
                }
                else
                {
                    projectileScript.SetInitialDirection(_shootPoint.forward * _shootSpeed);
                }

                yield return new WaitForSeconds(_shootInterval);
                _shootBool = true;
            }
        }
    }
}
