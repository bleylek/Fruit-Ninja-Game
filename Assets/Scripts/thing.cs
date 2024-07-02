using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thing : MonoBehaviour
{
    private Vector2 sweepStart; // The starting point of the swipe gesture
    public GameObject cutPf; // The prefab for the cut effect
    public float Ltime; // The lifetime of the cut effect
    private bool dg; // Flag to indicate if a cutting gesture is ongoing

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect when the mouse button is pressed down
        {
            dg = true; // Set the flag to indicate that cutting has started
            sweepStart = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Record the starting position of the swipe
        }
        else if (Input.GetMouseButtonUp(0) && dg) // Detect when the mouse button is released and a cutting gesture was ongoing
        {
            dg = false; // Reset the flag to indicate that cutting has ended
            SpawnerForCutting(); // Call the method to create the cut effect
        }
    }

    private void SpawnerForCutting()
    {
        Vector2 endOfSweep = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Record the ending position of the swipe
        GameObject cutInstance = Instantiate(cutPf, sweepStart, Quaternion.identity); // Instantiate the cut effect at the starting position with default rotation

        // Set the positions for the LineRenderer to draw the cut line
        cutInstance.GetComponent<LineRenderer>().SetPosition(0, sweepStart); // Set the starting position of the cut line
        cutInstance.GetComponent<LineRenderer>().SetPosition(1, endOfSweep); // Set the ending position of the cut line

        // Define the points for the EdgeCollider2D to match the cut line
        Vector2[] collidePoints = new Vector2[2]; // Create an array to hold the points of the collider
        collidePoints[0] = Vector2.zero; // The first point is at the origin (relative to the cut instance)
        collidePoints[1] = endOfSweep - sweepStart; // The second point is the direction and length of the swipe

        cutInstance.GetComponent<EdgeCollider2D>().points = collidePoints; // Assign the points to the collider
        Destroy(cutInstance, Ltime); // Destroy the cut effect after its lifetime expires
    }
}
