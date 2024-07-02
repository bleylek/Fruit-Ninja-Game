using UnityEngine;

public class Cutting : MonoBehaviour
{
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the GameManager object
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    // Handle trigger collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is tagged as "fruit"
        if (other.CompareTag("fruit"))
        {
            Destroy(other.gameObject); // Destroy the fruit
            manager.score += 1; // Increment the score
        }
        // Check if the collided object is tagged as "bomb"
        else if (other.CompareTag("bomb"))
        {
            manager.restart(); // Restart the game
            Debug.Log("Game Over"); // Log game over message
        }
    }
}
