using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveHandlerPlayer : MonoBehaviour
{
    
    public float _strartSpeed = 15;
    public float _startTurnSpeed = 20;
    
    private float _speed;
    private float _turnSpeed;
    private void Start()
    {
        _speed = _strartSpeed;
        _turnSpeed = _strartSpeed;
    }

    private void Update()
    {
        // Получаем нажатые кнопки.
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        // Вычисляем шаг за кадр.
        var step = Time.deltaTime * _speed;

        // Меняем позицию игрока в соответствии с нажатыми кнопками.
        transform.Translate(Vector3.forward * step * verticalInput);

        // Вычисляем угол вращения за кадр.
        var rotationAngle = Time.deltaTime * _turnSpeed;

        // Вращаем игрока в соответствии с нажатыми кнопками.
        transform.Rotate(Vector3.up, rotationAngle * horizontalInput);
    }

    public void InitializeSpeed(float speed, float turnSpeed)
    {
        _speed = speed;
        _turnSpeed = turnSpeed;
    }
}