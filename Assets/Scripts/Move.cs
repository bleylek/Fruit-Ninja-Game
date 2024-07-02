using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D RigidBody2D; // Reference to the Rigidbody2D component for physics-based movement
    public float life; // The lifetime of the fruit object before it disappears
    public float maxX; // Maximum x component of the initial velocity
    public float maxY; // Maximum y component of the initial velocity
    public float minX; // Minimum x component of the initial velocity
    public float minY; // Minimum y component of the initial velocity

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial velocity of the Rigidbody2D to a random value within the specified ranges
        RigidBody2D.velocity = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Destroy the game object after a specified lifetime
        Destroy(gameObject, life);
    }
}
