using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject missilePrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    private int randomEnemy;
    private int randomPowerup;
    private bool powerupMissile;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
        //powerupMissile = player.GetComponent<PlayerController>().activateMissile;
        //if (powerupMissile == true)
        //{
        //    Debug.Log(powerupMissile);
        //    powerupMissile = false;
        //    SpawnMissile();            
        //}
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            randomEnemy = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition(), enemyPrefab[randomEnemy].transform.rotation);
            if (enemyPrefab[randomEnemy].CompareTag("EnemyStronger"))
            {
                enemyPrefab[randomEnemy].GetComponent<Enemy>().speed = 2.5f;
                enemyPrefab[randomEnemy].GetComponent<Rigidbody>().mass = 2.2f;
            }
        }
    }

    void SpawnPowerup()
    {
        randomPowerup = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[randomPowerup], GenerateSpawnPosition(), powerupPrefab[randomPowerup].transform.rotation);
    }

    void SpawnMissile()
    {        
        for (int a = 0; a < 4; a++)
        {
            WaitToShoot();
            Instantiate(missilePrefab, new Vector3(player.transform.position.x + 1, 0, player.transform.position.z + 1), missilePrefab.transform.rotation);
        }        
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(1);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
