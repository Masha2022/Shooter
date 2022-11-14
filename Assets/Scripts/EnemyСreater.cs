using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyСreater : MonoBehaviour
{
    public Action DecreaseEnemiesEvent;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private MoveHandlerPlayer _player;
    [SerializeField] private int _health = 50;
    private int _randomRadius = 30;
    private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] public int _startCountEnemies = 5;

    private void Start()
    {
        CreateNewEnemy();
    }

    private void CreateNewEnemy()
    {
        for (int i = 0; i < _startCountEnemies; i++)
        {
            var enemy = Instantiate(_enemyPrefab);
            SetEnemyPosition(enemy);
            enemy.GetComponent<MoveHandlerEnemy>().Initialize(_player);
            enemy.GetComponent<EnemyDestroy>().InitializeHealth(_health);
            _enemies.Add(enemy);
        }
    }

    private void Update()
    {
        ChangedCountEnemies();
    }

    public void ChangedCountEnemies()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == null)
            {
                _enemies.Remove(_enemies[i]);
                GameManager.SendEnemyKilled(_enemies.Count);
            }
        }

        if (_enemies.Count == 0)
        {
            CreateNewEnemy();
        }
    }

    private void SetEnemyPosition(GameObject enemy)
    {
        var randomPosition = Random.insideUnitCircle * _randomRadius;
        var enemyPosition = enemy.transform.position;

        enemyPosition.x += randomPosition.x;
        enemyPosition.z += randomPosition.y;

        enemy.transform.position = enemyPosition;
    }
}