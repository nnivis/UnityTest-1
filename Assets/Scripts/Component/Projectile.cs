using UnityEngine;

namespace TowerDefence
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float _speed = 10f;
        float _lifetime = 3.0f;
        float _currentLifetime;
        Vector3 _initialDirection;

        public void SetInitialDirection(Vector3 direction)
        {
            _initialDirection = direction;
        }
        void Start()
        {
            GetComponent<Rigidbody>().velocity = _initialDirection.normalized * _speed;
        }
        void Update()
        {
            _currentLifetime += Time.deltaTime;

            if (_currentLifetime >= _lifetime)
            {
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
