using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private WeaponsController _weaponsController;
    private Weapon _currentWeapon;


    private void OnDestroy()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.ShootEvent -= OnShoot;
        }
        _weaponsController.WeaponChanged -= OnWeaponChanged;
    }

    public void Initialize(WeaponsController weaponsController)
    {
        _weaponsController = weaponsController;
        _weaponsController.WeaponChanged += OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon weapon)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.ShootEvent -= OnShoot;
        }
        _currentWeapon = weapon;
        _text.text = weapon.BulletsCount.ToString();
        weapon.ShootEvent += OnShoot;
    }

    private void OnShoot(int bullet)
    {
        _text.text = bullet.ToString();
    }
}