using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    float input;

    public PlayerData playerData;
    public float speed => playerData.DefaultSpeed;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.right * (input * speed);
    }

    public void ApplyPowerup(Powerup powerup)
    {
        print("received powerup");

        switch (powerup.type)
        {
            case Powerup.PowerupType.None:
                break;
            
            case Powerup.PowerupType.Stretch:
                transform.localScale += Vector3.right * 0.25f;
                break;
            
            case Powerup.PowerupType.Shrink:
                transform.localScale -= Vector3.right * 0.25f;
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
