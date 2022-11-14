using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDestroy : MonoBehaviour
{
    public Action  EnemyDiedEvent;
    
    [SerializeField] private GameObject _enemy;
    private Material _material;
    private Color _color;
    private int _healthEnemy;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pool"))
        {
            if (_healthEnemy >= 0)
            {
                _healthEnemy -= 50;
                _color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 1f, 1f);
                GetComponent<Renderer>().material.color = _color;
                return;
            }
            if (_healthEnemy < 0)
            {
                Destroy(_enemy);
            }
        }
    }

    public void InitializeHealth(int health)
    {
        _healthEnemy = health;
    }
}