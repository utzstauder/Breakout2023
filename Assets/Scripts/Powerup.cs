using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Picked up by: " +  collision.gameObject.name);

        // TODO: apply powerup effect
    }
}
