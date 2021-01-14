using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private void OnEnable()
    {
        FinishLogic.onPlayerFinishCollision += StopPlayerMovement;
    }

    private void OnDisable()
    {
        FinishLogic.onPlayerFinishCollision -= StopPlayerMovement;

    }

    private void StopPlayerMovement()
    {
        if (TryGetComponent(out Rigidbody2D rb))
            rb.velocity = Vector3.zero;
    }
}
