using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int _level;
    [SerializeField] private Vector3 playerStartPosition;
    [SerializeField] private Transform player;

    private void OnEnable()
    {
        Enemy.onCollisionWithEnemy += GameOver;
        FinishLogic.onPlayerFinishCollision += Win;
    }

    private void OnDisable()
    {
        Enemy.onCollisionWithEnemy -= GameOver;
        FinishLogic.onPlayerFinishCollision -= Win;
    }

    void Start()
    {
        player.position = playerStartPosition;
    }

    private void Win()
    {
        print("win");
        StartCoroutine(LoadNextLevel());
        
    }
    
    private void GameOver()
    {
        print("gg");
        StartCoroutine(ReloadScene());
        
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(0);
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}
