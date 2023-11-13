using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    float input;

    public float speed = 1f;

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
        rigidbody2D.velocity = Vector2.right * input * speed;
    }
}
