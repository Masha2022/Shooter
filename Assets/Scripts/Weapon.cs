using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    public Action<int> ShootEvent; // для хранения количества пуль
    public int BulletsCount { get; private set; }

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletVelocity = 70f;
    [SerializeField] private int _startBulletsCount = 35;

    private void Awake()
    {
        BulletsCount = _startBulletsCount;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (BulletsCount > 0)
            {
                BulletsCount--;
                ShootEvent?.Invoke(BulletsCount);
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletVelocity;
        }
    }
}