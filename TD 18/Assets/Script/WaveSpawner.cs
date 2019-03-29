
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countDown = 5f;
    public Text waveCountdownText;
    private int waveIndex = 1;

    void Update()
    {
        if(countDown <=0f)
        {
            StartCoroutine(SwawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0, 1000);
        waveCountdownText.text = string.Format("{0:00.00}", countDown);
     //   Mathf.Round(countDown).ToString();
    }
    IEnumerator SwawnWave()
    {
        waveIndex++;
        PlayerStats.Round++;

        for (int i = 0; i < waveIndex; i++)
         {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
         }        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab , spawnPoint.position, spawnPoint.rotation);
    }
}
