using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int enemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;
    public GameMaster gameMaster;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 0;

    public Text waveCountdonText;

    void Update()
    {

        if(enemiesAlive>0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdonText.text = string.Format("{0:00.00}", countdown);

        if(countdown<=3)
        {
            waveCountdonText.color = Color.red;
        }
        else
        {
            waveCountdonText.color = Color.white;
        }

    }
	
    IEnumerator SpawnWave()
    {
        

        PlayerStats.rounds++;

        Wave wave = waves[waveNumber];

        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveNumber++;

        if(waveNumber==waves.Length)
        {
            Debug.Log("new level");
            gameMaster.WinLevel();
            this.enabled = false;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

    }



}
