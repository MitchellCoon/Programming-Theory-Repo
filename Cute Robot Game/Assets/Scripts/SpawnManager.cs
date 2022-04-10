using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Vector3 playerSpawn = new Vector3(0,0.42f,-4.0f);
    float enemySpawnRangeX = 8.0f;
    float enemySpawnRangeZ = 2.0f;
    int waveNumber = 1;
    public Robot fastboi;
    public Robot edgelord;
    public Robot chonker;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(MainManager.Instance.robot, playerSpawn, MainManager.Instance.robot.gameObject.transform.rotation);
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0)
        {
            waveNumber++;
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        for(int i = 0; i < waveNumber; i++)
        {
            float spawnX = Random.Range(-enemySpawnRangeX, enemySpawnRangeX);
            float spawnZ = 6.0f + Random.Range(-enemySpawnRangeZ, enemySpawnRangeZ);
            Vector3 enemySpawn = new Vector3(spawnX, 0.42f, spawnZ);
            int enemyType = Random.Range(0,3);
            switch(enemyType)
            {
                case 0:
                    Instantiate(fastboi, enemySpawn, fastboi.transform.rotation);
                    break;
                case 1:
                    Instantiate(edgelord, enemySpawn, edgelord.transform.rotation);
                    break;
                case 2:
                    Instantiate(chonker, enemySpawn, chonker.transform.rotation);
                    break;
            } 
            
        }
    }
}
