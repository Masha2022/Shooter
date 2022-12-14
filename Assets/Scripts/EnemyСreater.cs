using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyСreater : MonoBehaviour
{
    public Action<int> DecreaseEnemiesEvent;
    [SerializeField] public EnemyDestroy _enemyDied;
    [SerializeField] public int _startCountEnemies = 5;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private MoveHandlerPlayer _player;
    [SerializeField] private int _health = 50;
    private int _randomRadius = 30;
    private List<GameObject> _enemies = new List<GameObject>();


    private void Awake()
    {
        _enemyDied.EnemyDiedEvent += OnEnemyDied;
    }

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
            enemy.GetComponent<EnemyDestroy>().InitializeHealth(_health, OnEnemyDied);
            _enemies.Add(enemy);
        }
    }

    public void OnEnemyDied(GameObject enemy)
    {
        _enemies.Remove(enemy);
        DecreaseEnemiesEvent?.Invoke(_enemies.Count);
        if (_enemies.Count == 0)
        {
            _startCountEnemies = 5;
            DecreaseEnemiesEvent?.Invoke(_startCountEnemies);
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