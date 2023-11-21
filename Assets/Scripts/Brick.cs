using UnityEngine;

public class Brick : MonoBehaviour
{
    public delegate void BrickHitDelegate(Brick brickThatWasHit);
    public event BrickHitDelegate OnBrickHit;

    public static event BrickHitDelegate OnBrickDestroyed;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);

        OnBrickHit?.Invoke(this);
        
        // TODO: implement HP for bricks
        
        OnBrickDestroyed?.Invoke(this);
    }
}
