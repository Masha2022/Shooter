using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesCountView : MonoBehaviour
{

   [SerializeField] private Image[] _images = new Image[5];
   [SerializeField] private EnemyСreater _enemyController;
   private int _countAliveEnemies;

   private void EnemiesAlive(int aliveEnemy)
   {
       Debug.Log("EnemiesCountView, aliveEnemy = "+aliveEnemy);
       _images[aliveEnemy].enabled = false;
       if (aliveEnemy == 0)
       {
           foreach (var image in _images)
           {
               image.enabled = true;
           }
       }
   }

   public void Initialize(int enemyAlive)
   {
       _enemyController.DecreaseEnemiesEvent += EnemiesAlive;
       _countAliveEnemies = enemyAlive;
       Debug.Log("EnemiesCountView, _countAliveEnemies = "+_countAliveEnemies);
       Debug.Log("EnemiesCountView, enemyAlive = "+enemyAlive);
   }
}