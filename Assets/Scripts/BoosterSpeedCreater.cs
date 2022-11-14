using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpeedCreater : MonoBehaviour
{
    [SerializeField] public GameObject _prefabBooster;
    private int _boostersCount = 1;
    [SerializeField]
    private int _randomRadius = 5;
    
    private void Start()
    {
        for (var i = 0; i < _boostersCount; i++)
        {
            var booster = Instantiate(_prefabBooster);
            SetBoostersPosition(booster);
        }
    }

    private void SetBoostersPosition(GameObject booster)
    {
        var randomPosition = Random.insideUnitCircle * _randomRadius;
        var boosterPosition = booster.transform.position;
        
        boosterPosition.x += randomPosition.x;
        boosterPosition.z += randomPosition.y;

        booster.transform.position = boosterPosition;
    }
}