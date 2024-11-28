using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]    
    private float wavesCoolDown = 5.5f;

    private float countDown = 6f;
        [SerializeField]    
    private Text wavesCountDownTimer;

    private int WaveIndex = 0;
    // Start is called before the first frame update
   /*  void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (countDown <=0f)
        {
            StartCoroutine(SpawnWaves());
            countDown = wavesCoolDown;
        }
        countDown -= Time.deltaTime;
        
        wavesCountDownTimer.text = Mathf.Clamp(Mathf.Round(countDown),0f,Mathf.Infinity).ToString();
    } 

    IEnumerator SpawnWaves()
    {
        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }
    
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,SpawnPoint.position, SpawnPoint.rotation);
    }
}
