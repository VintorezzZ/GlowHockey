using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private LevelGenerator _levelGenerator;
    
    public static int _level = 1;
    private float _reloadTime = 2;

    [SerializeField] private Vector3 playerStartPosition = new Vector3(0, -3, 0);
    [SerializeField] private Transform player;

    private bool _isGameOver = false;

    public delegate void OnLevelChanged(int level);
    public static event OnLevelChanged onLevelChanged;
    
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

        _levelGenerator = FindObjectOfType<LevelGenerator>();
        _levelGenerator.GenerateLevel();
        
        onLevelChanged?.Invoke(_level);
    }

    private void Win()
    {
        if(_isGameOver)
            return;
        
        //print("win");
        StartCoroutine(LoadNextLevel());
    }
    
    private void GameOver()
    {
        if(_isGameOver)
            return;

        _isGameOver = true;
        TurnOnSlowMotionEffect();
        //print("gg");
        StartCoroutine(ReloadScene());
        
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(_reloadTime);
        _isGameOver = false;
        TurnOffSlowMotionEffect();
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.position = playerStartPosition;
    }

    private IEnumerator LoadNextLevel()
    {
        GAManager.OnLevelComplete(_level);
        
        yield return new WaitForSecondsRealtime(_reloadTime);

        _level++;
        onLevelChanged?.Invoke(_level);

        player.transform.position = playerStartPosition;
        _levelGenerator.DeActivateEnemiesAndFinish();
        _levelGenerator.GenerateLevel();
    }

    private void TurnOnSlowMotionEffect()
    {
        Time.timeScale = 0.3f;
    }
    private void TurnOffSlowMotionEffect()
    {
        Time.timeScale = 1;
    }
}
