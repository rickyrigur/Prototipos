using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 10;
    private float spawnPosZ = 20;
    private float spawnPosX = 20;
    private float startDelay = 2;
    private float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    void SpawnRandomAnimal() 
    {
        Vector3 spawnPosUp = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Vector3 spawnPosLeft = new Vector3(-spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Vector3 spawnPosRight = new Vector3(spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPosUp, animalPrefabs[animalIndex].transform.rotation);
        Instantiate(animalPrefabs[animalIndex], spawnPosLeft, Quaternion.Euler(0, 90, 0));
        Instantiate(animalPrefabs[animalIndex], spawnPosRight, Quaternion.Euler(0, 270, 0));
    }
    
}
