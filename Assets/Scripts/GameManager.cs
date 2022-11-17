using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BulletCountView _bulletCountView;
    [SerializeField] private WeaponsController _weaponsController;

    [SerializeField] private EnemiesCountView _enemiesCountView;
    [SerializeField] private EnemyСreater _enemyDied;
    private int _count;
    
    private void Awake()
    {
        _bulletCountView.Initialize(_weaponsController);
        _count = _enemyDied._startCountEnemies;
        _enemiesCountView.Initialize(_count);
        Debug.Log(" GameManager _count =" + _count);
    }
}