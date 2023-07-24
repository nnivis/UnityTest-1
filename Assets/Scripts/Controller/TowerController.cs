using UnityEngine;

namespace TowerDefence
{
    public class TowerController : MonoBehaviour
    {
         ShooterBase _shooter;
        TargetDetectionComponent _targetDetectionComponent;

        void Start()
        {
             _shooter = GetComponent<ShooterBase>();
            _targetDetectionComponent = GetComponent<TargetDetectionComponent>();

        }

        void Update()
        {
            if (_targetDetectionComponent.TargetDetection())
            {
                _shooter.Shoot();
            }
        }
    }
}
