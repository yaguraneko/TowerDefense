using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform[] Points; // Array of waypoints for the enemy to follow
    [SerializeField] float speed = 2f;   // Movement speed
    int pointIndex = 0;                  // Current waypoint index

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the enemy's position to the first waypoint
        transform.position = Points[pointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointIndex < Points.Length) // Check if there are remaining waypoints
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, Points[pointIndex].position, speed * Time.deltaTime);

            // Check if the enemy is close enough to the current waypoint
            if (Vector3.Distance(transform.position, Points[pointIndex].position) < 0.1f)
            {
                pointIndex++; // Move to the next waypoint
            }
        }
        else
        {
            // Add logic here for when the enemy has reached the end
            Debug.Log("Enemy reached the final point!");
        }
    }

    // Trigger a collision event with defenders
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("defender"))
        {
            speed = 0; // Stop the enemy when colliding with a defender
        }
    }
}
