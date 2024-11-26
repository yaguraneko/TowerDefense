using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] ParticleSystem ShiledVFX;
    [SerializeField] AudioClip ShiledBreak, DeathSFX;
    [SerializeField] GameObject Death;
    [SerializeField] Animator enemyAnim;
    public Transform[] Points; // Array of waypoints for the enemy to follow
    public float speed = 2f;   // Movement speed
    public int HealthPoint;
    int pointIndex = 1, moeny = 1;
    
    void Start()
    {
        enemyAnim.Play("SlimeJump", 0, Random.Range(0f, 1f));
        enemyAnim.speed = speed/3;
        GlobalData.AliveSlimes++;
        moeny *= (int)speed * HealthPoint;
        if (HealthPoint > 1)
            SetBurstCount(HealthPoint);
        else
            Destroy(ShiledVFX);
    }

    void Update()
    {
        if (GlobalData.GameOver.activeSelf)
            Destroy(gameObject);
        if (pointIndex < Points.Length) // Check if there are remaining waypoints
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, Points[pointIndex].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Points[pointIndex].rotation, speed * 100 * Time.deltaTime);
            // Check if the enemy is close enough to the current waypoint
            if (Vector3.Distance(transform.position, Points[pointIndex].position) < 0.1f)
                pointIndex++; // Move to the next waypoint
        }
        else
        {
            // Add logic here for when the enemy has reached the end
            GlobalData.AliveSlimes--;
            GlobalData.lose = true;
            GlobalData.PlayerHP--;
            GlobalData.hleathText.SetText($"{GlobalData.PlayerHP}");
            if (GlobalData.PlayerHP < 1)
                GlobalData.GameOver.SetActive(true);
            Destroy(gameObject);
        }
    }

    void SetBurstCount(int count)
    {
        if (count == 1)
        {
            Destroy(ShiledVFX);
            return;
        }

        var emission = ShiledVFX.emission;

        ParticleSystem.Burst burst = new ParticleSystem.Burst(0f, count);  // Time = 0, Count = `count`

        ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[1]; // Create a new array with 1 burst
        bursts[0] = burst; // Assign the new burst to the array
        emission.SetBursts(bursts); // Set the burst array
        ShiledVFX.Play();  // Ensure it's playing to apply the new burst
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("arrow"))
            AddDamage(1);
    }

    void AddDamage(int damage)
    {
        HealthPoint -= damage;
        if (HealthPoint < 1)
        {
            GlobalData.AudioManager(DeathSFX, transform.position, .5f);
            Destroy(Instantiate(Death, transform.position, transform.rotation), 4);
            GlobalData.Money += moeny;
            GlobalData.MoneyText.SetText($"{GlobalData.Money}$");
            GlobalData.AliveSlimes--;
            Destroy(gameObject);
        }
        else
        {
            SetBurstCount(HealthPoint);
            GlobalData.AudioManager(ShiledBreak, transform.position, .1f);
        }
    }
}
