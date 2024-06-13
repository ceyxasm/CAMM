using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Public variable to set the score value for this collectible
    public int scoreValue = 1;

    // When the player collides with the collectible, increase the score and destroy the collectible
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Increase the player's score
            GameManager.Instance.AddScore(scoreValue);
            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
