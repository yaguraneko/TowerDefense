using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform[] Points; // Array of waypoints for the enemy to follow
    public float speed = 2f;   // Movement speed
    public float HealthPoint = 1;
    [SerializeField] GameObject shield, SlimeDeath, FastSlimDeath;
    int pointIndex = 0;                  // Current waypoint index

    // Update is called once per frame
    void Start()
    {
        if (HealthPoint == 2)
            shield.SetActive(true);
        Debug.Log(speed);
        Debug.Log(HealthPoint);
    }
    void Update()
    {
        if (pointIndex < Points.Length) // Check if there are remaining waypoints
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, Points[pointIndex].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Points[pointIndex].rotation, speed * 250 * Time.deltaTime);
            // Check if the enemy is close enough to the current waypoint
            if (Vector3.Distance(transform.position, Points[pointIndex].position) < 0.1f)
                pointIndex++; // Move to the next waypoint
        }
        else
            // Add logic here for when the enemy has reached the end
            Debug.Log("Enemy reached the final point!");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.name); // Log for debugging
        if (other.CompareTag("arrow"))
        {
            if (HealthPoint == 2)
                Destroy(shield);
            else
            {
                CallDeath();
                Destroy(gameObject);
            }
        }
    }

    void CallDeath()
    {
         GameObject newEnemy = Instantiate(speed == 6 ? FastSlimDeath : SlimeDeath, transform.position, transform.rotation);
    }

}
