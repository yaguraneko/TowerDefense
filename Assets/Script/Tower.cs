//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage;
    public int towerType;
    private Transform target;
    public float range = 2f;
    public Transform partToRotate;

    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f , 0.5f);        
    }

    // Update is called once per frame
    void Update()
    {
        if(target ==null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void UpdateTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = range * 2;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
