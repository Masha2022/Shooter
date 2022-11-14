using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public Action<Weapon> WeaponChanged;

    [SerializeField] private List<Weapon> _weapons; //настраиваемый лист с оружием
    private Weapon _activeWeapon; //текущее оружие
    private int _activeWeaponIndex; //индекс текущего оружия

    private void Awake()
    {
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        _activeWeapon = _weapons[_activeWeaponIndex]; // присваиваю в текущее оружие новое оружие
        _activeWeapon.gameObject.SetActive(true); //включаю новое оружие
        WeaponChanged?.Invoke(_activeWeapon);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _activeWeapon.gameObject.SetActive(false); // выключаю оружие
            _activeWeaponIndex = (_activeWeaponIndex + 1) % _weapons.Count; //добавляю текущий индекс
            ChangeWeapon();
        }
    }
}