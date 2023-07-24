using UnityEngine;

namespace TowerDefence
{
    public class EnemyMovementConponent : MonoBehaviour
    {
        float _speed = 0.05f;
        float _reachDistance = 0.3f;

        public void Move(GameObject moveTraget)
        {
            var moveLocalTarget =  moveTraget;

            if (Vector3.Distance(transform.position, moveLocalTarget.transform.position) < _reachDistance)
            {
                Destroy(gameObject);
                return;
            }

            var translation = moveLocalTarget.transform.position - transform.position;
            if (translation.magnitude > _speed)
            {
                translation = translation.normalized * _speed;
            }

            transform.Translate(translation);
        }
    }
}
