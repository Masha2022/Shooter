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

   private void EnemiesAlive(int countAliveEnemy)
   {
       Debug.Log("EnemiesCountView, countAliveEnemy = "+countAliveEnemy);
       for (var enemyIndex = 0; enemyIndex < _images.Length; enemyIndex++)
       {
           _images[enemyIndex].enabled = enemyIndex < countAliveEnemy;
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