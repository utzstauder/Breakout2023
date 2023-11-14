using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType
    {
        None,
        Stretch,
        Shrink,
    }

    public PowerupType type;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        Player player = collision.gameObject.GetComponent<Player>();
        player.ApplyPowerup(this);

        Destroy(gameObject);
    }
}
