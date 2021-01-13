using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLogic : MonoBehaviour
{
    public delegate void OnPlayerFinishCollision();
    public static event OnPlayerFinishCollision onPlayerFinishCollision;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("finish");
            onPlayerFinishCollision?.Invoke();
        }
    }
}
