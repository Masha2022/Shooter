using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] private GameObject Bulllet;
   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(Bulllet);
    }
}