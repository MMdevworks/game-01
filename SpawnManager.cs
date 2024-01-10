using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;

    public GameObject powerupPrefab;

    public float spawnRange = 9.0f;

    //change these locations later    
    public float spawnRangeX = 20;
    public float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {   
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //** eventually refactor and move down to a new StartGame function after buttons added
        // Repeatedly call SpawnRandomEnemy function after a delay and at the given intervals
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
    }
    
    // Randomize the enemy index and spawn position Random.Range(x,y,z)
    void SpawnRandomEnemy(){
        if(gameManager.isGameActive){
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos,
        enemyPrefabs[enemyIndex].transform.rotation);
        }
    }

    //method returns random pos
    private Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;

    }
}

