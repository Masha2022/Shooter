using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandlerBoosterSpeed : MonoBehaviour
{
    [SerializeField] public MoveHandlerPlayer _player;
    
    private float _newSpeed;
    private float _newTurnSpeed;

    private void Start()
    {
        _newSpeed = _player.GetComponent<MoveHandlerPlayer>()._strartSpeed;
        _newTurnSpeed =  _player.GetComponent<MoveHandlerPlayer>()._startTurnSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player") )
        {
            _newTurnSpeed *= 2;
            _newSpeed *= 2;
            
            _player.GetComponent<MoveHandlerPlayer>().InitializeSpeed(_newSpeed, _newTurnSpeed);
            Destroy(gameObject);
        }
    }
}