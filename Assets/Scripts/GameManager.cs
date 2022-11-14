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
    
    public static UnityEvent<int> OnEnemyKilled= new UnityEvent<int>();

    private void Awake()
    {
        _bulletCountView.Initialize(_weaponsController);
    }
    
    public static void SendEnemyKilled(int killedEnemy)
    {
        OnEnemyKilled?.Invoke( killedEnemy);
    }
 
}
