using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void OnCollisionWithEnemy();
    public static event OnCollisionWithEnemy onCollisionWithEnemy;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // INSTANTIATE PARTICLES
            // GAME OVER
            //print("hit");
            onCollisionWithEnemy?.Invoke();
        }
    }
}
