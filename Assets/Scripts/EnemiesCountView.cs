using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesCountView : MonoBehaviour
{

   [SerializeField] private Image[] _images = new Image[5];
   private void Awake()
   {
       GameManager.OnEnemyKilled.AddListener(EnemyKilled);
   }

   private void EnemyKilled(int killedEnemy)
   {
       _images[ killedEnemy].enabled = false;
       if (killedEnemy == 0)
       {
           foreach (var image in _images)
           {
               image.enabled = true;
           }
       }
   }

}