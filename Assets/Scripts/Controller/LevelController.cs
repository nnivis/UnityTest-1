using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] GameObject _monsterSpawnPrefab;
        [SerializeField] SpawnerEnemyComponent _spawner;

        void Start()
        {
            _spawner.SetSpawnInfo(_monsterSpawnPrefab);
            _spawner.StartSpawning();
        }
        

    }
}