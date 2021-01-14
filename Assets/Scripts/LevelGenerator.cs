using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemySpawnPoints;
    [SerializeField] private List<GameObject> enemyMiddleSpawnPoints;
    [SerializeField] private List<GameObject> finishSpawnPoints;
    
    private int _enemiesToSpawnCount;

    public void GenerateLevel()
    {
        SetEnemiesCount();

        SetFinishObject();

        for (int i = 1; i <= _enemiesToSpawnCount; i++)
        {
            if(i == 1)
                SpawnOneEnemyAtMiddle();
            else
                SpawnOtherEnemies();
        }
    }

    private void SetFinishObject()
    {
        int randomFinishIndex = Random.Range(0, finishSpawnPoints.Count);
        finishSpawnPoints[randomFinishIndex].SetActive(true);
    }

    private void SetEnemiesCount()
    {
        if (GameManager._level < 5)
        {
            _enemiesToSpawnCount = GameManager._level;
        }
        else
        {
            _enemiesToSpawnCount = Random.Range(3, 6);
        }
    }

    private void SpawnOneEnemyAtMiddle()
    {
        int randomMiddleEnemyIndex = Random.Range(0, enemyMiddleSpawnPoints.Count);
        enemyMiddleSpawnPoints[randomMiddleEnemyIndex].SetActive(true);
    }

    private void SpawnOtherEnemies()
    {
        int randomIndex = Random.Range(0, enemySpawnPoints.Count);
        enemySpawnPoints[randomIndex].SetActive(true);
    }

    public void DeActivateEnemiesAndFinish()
    {
        foreach (var enemy in enemySpawnPoints)
        {
            enemy.SetActive(false);
        }

        foreach (var enemy in enemyMiddleSpawnPoints)
        {
            enemy.SetActive(false);
        }

        foreach (var finish in finishSpawnPoints)
        {
            finish.SetActive(false);
        }
    }
}