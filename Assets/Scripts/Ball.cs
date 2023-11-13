using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    public Vector2 initialVelocity = Vector2.up;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2D.velocity = initialVelocity;
    }
}
