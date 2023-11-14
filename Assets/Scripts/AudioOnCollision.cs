using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioOnCollision : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}