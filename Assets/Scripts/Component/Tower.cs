using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] CannonTowerData _data;
        [HideInInspector] public TargetDetectionComponent targetDetectionComponent;
        [HideInInspector] public ShootCannonTowerComponent shootCannonTowerComponent;

        [HideInInspector] public ShootParabolicTowerComponent shootParabolicTowerComponent;

        void Start()
        {
            if (TryGetComponent(out targetDetectionComponent))
            {
                targetDetectionComponent.Init(_data.speedLookTargetData, _data.detectionRadius);
            }

            if (TryGetComponent(out shootCannonTowerComponent))
            {
                shootCannonTowerComponent.Init(_data.shootInterval, _data.shootSpeed);
            }

             if (TryGetComponent(out shootParabolicTowerComponent))
            {
                shootParabolicTowerComponent.Init(_data.shootInterval, _data.shootSpeed);
            }

        }
    }
}
