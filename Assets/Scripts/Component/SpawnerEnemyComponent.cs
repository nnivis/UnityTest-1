using UnityEngine;
using System.Collections;

namespace TowerDefence

{
    public class SpawnerEnemyComponent : MonoBehaviour
    {
        GameObject _monsterPrefab;
        float _spawnTime = 5.0f;
        bool _spawn = true;

        public void SetSpawnInfo( GameObject monsterPrefab)
        {
            _monsterPrefab = monsterPrefab;
        }

        public void StartSpawning()
        {
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (_spawn)
            {
                _spawn = false;
                yield return new WaitForSeconds(_spawnTime);

                var monster = Instantiate(_monsterPrefab);
                monster.transform.position = transform.position;

                _spawn = true;
            }
        }

    }
}
