using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform[] Points; // Array of waypoints for the enemy to follow
    [SerializeField] GameObject EnemyPrefab; // The enemy prefab to spawn
    [SerializeField] Transform SpawnPoint;
    public int EnemyCount, wave;
    public float speed=8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount > 0)
        {
            EnemyCount--;
            GameObject newEnemy = Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyScript>().Points = Points;

            float threshold = (1f / wave + 0.05f)* Time.deltaTime; // Calculate threshold based on wave
            // Use the threshold to determine speed and health
            newEnemy.GetComponent<EnemyScript>().speed =speed; //Random.Range(0f, 1f) > threshold ? 10 : 5;
            newEnemy.GetComponent<EnemyScript>().HealthPoint =3; //Random.Range(0f, 1f) > threshold ? 2 : 1;

            // Log for debugging
            Debug.Log($"wave: {wave}, Threshold: {threshold}");
            yield return new WaitForSeconds(1);
        }
    }
}
