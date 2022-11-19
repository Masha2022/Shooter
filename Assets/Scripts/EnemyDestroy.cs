using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDestroy : MonoBehaviour
{
    public Action<GameObject> EnemyDiedEvent;

    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _damage = 50;
    private Material _material;
    private Color _color;
    private int _healthEnemy;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pool"))
        {
            if (_healthEnemy > 0)
            {
                _healthEnemy -= _damage;
                _color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 1f, 1f);
                GetComponent<Renderer>().material.color = _color;
                return;
            }

            if (_healthEnemy <= 0)
            {
                Debug.Log("EnemyDestroy, Destroy(_enemy)");
                Destroy(_enemy);
                EnemyDiedEvent?.Invoke(_enemy);
            }
        }
    }

    public void InitializeHealth(int health, Action<GameObject> enemyDiedEvent)
    {
        EnemyDiedEvent = enemyDiedEvent;
        _healthEnemy = health;
    }
}