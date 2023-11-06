using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    public delegate void BrickHitDelegate(Brick brickThatWasHit);
    public event BrickHitDelegate OnBrickHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);

        OnBrickHit?.Invoke(this);
    }
}
