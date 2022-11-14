using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandlerEnemy : MonoBehaviour
{
     public MoveHandlerPlayer _player;
     public GameObject _enemy;
     
     private float _speed = 1f;
   
    public void Initialize(MoveHandlerPlayer player)
    {
        _player = player;
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = _enemy.transform.localPosition - _player.transform.localPosition;
        Quaternion quaternion = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, _speed*Time.deltaTime);
        
        // Переместим нашу позицию на шаг ближе к цели. 
        var step = _speed * Time.deltaTime; // расчет расстояния для перемещения 
        transform.position = Vector3.MoveTowards(_enemy.transform.position, _player.transform.position, step);
        // Проверяем, приблизительно ли равны положения игрока и врага
        if (Vector3.Distance( _enemy.transform.position, _player.transform.position) < 0.01f)
        {
            // Поменять положение врага. 
            _enemy.transform.position *= -1.0f;
        }
    }
}