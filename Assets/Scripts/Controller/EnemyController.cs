using UnityEngine;

namespace TowerDefence

{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] GameObject _moveTarget;
        EnemyMovementConponent _enemyMovementComponent;

        void Start()
        {
            _enemyMovementComponent = GetComponent<EnemyMovementConponent>();
        }

        void Update()
        {
            if (_moveTarget != null)
            {
                _enemyMovementComponent.Move(_moveTarget);
            }
            else
            {
                Debug.Log("Цель не установленна");
            }
        }
    }
}