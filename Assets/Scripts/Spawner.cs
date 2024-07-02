using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minX; // The minimum x position where objects can spawn
    public float maxX; // The maximum x position where objects can spawn
    public float sti; // The time interval between spawns
    public float time; // A timer to keep track of when to spawn the next object
    public GameObject pf; // The prefab of the object to be spawned
    public Sprite[] sprites; // Array of sprites to randomly assign to the spawned objects

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            spawn(); // Call the spawn method to spawn a new object
            time = sti; // Reset the timer to the specified interval
        }
        else
        {
            time -= Time.deltaTime; // Decrease the timer by the time elapsed since the last frame
        }
    }

    private void spawn()
    {
        GameObject newpf = Instantiate(pf); // Instantiate a new object from the prefab
        // Set the position of the new object to a random x position within the range and the same y position as the spawner
        newpf.transform.position = new Vector2(Random.Range(minX, maxX), transform.position.y);

        // Select a random sprite from the array of sprites
        Sprite random = sprites[Random.Range(0, sprites.Length)];

        // Assign the selected sprite to the new object's SpriteRenderer component
        newpf.GetComponent<SpriteRenderer>().sprite = random;
    }
}
