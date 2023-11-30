using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private float defaultSpeed = 10f;
        public float DefaultSpeed => defaultSpeed;

        [SerializeField] private Sprite[] sprites;

        public Sprite GetSprite(int size)
        {
            return sprites[size];
        }

        public void ApplyResize(Player playerRef, Powerup powerupRef)
        {
            
        }
    }
}
