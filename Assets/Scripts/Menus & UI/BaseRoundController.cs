using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRoundController : MonoBehaviour
{
    
    [SerializeField] private GameObject ratPrefab;
    [SerializeField] private GameObject badgerPrefab;

    [SerializeField] private List<GameObject> spawnerLocations;
    [SerializeField] private GameObject EnemyContainerArray;

    private int currentWave = 0;
    private Wave currentWaveInfo;

    public float spawnEverySeconds = 10.0f;
    public List<Wave> waves;

    public List<GameObject> spawners;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start Round");

        //autograb the arrays needed
        runWave();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void runWave()
    {
        //get the current wave in the specific wave
        currentWaveInfo = waves[currentWave];
        
        StartSpawning();
    }

    private void NextRound()
    {
        //incriment the round count
        currentWave++;
    }

    private void SpawnEnemy()
    {
        //randomly decide where the enmies will come from
        int locationId = Random.Range(0, spawnerLocations.Count);

        //randomly decide which enemy to spawn
        if (Random.Range(0,2) == 1)
        {
            if (currentWaveInfo.noOfRats > 0)
            {
                Instantiate(ratPrefab, 
                spawnerLocations[locationId].transform.position, 
                Quaternion.identity, 
                EnemyContainerArray.transform);

                currentWaveInfo.noOfRats--;
            }
        }
        else
        {
            if(currentWaveInfo.noOfBadgers > 0)
            {
                Instantiate(badgerPrefab, 
                spawnerLocations[locationId].transform.position, 
                Quaternion.identity, 
                EnemyContainerArray.transform);

                currentWaveInfo.noOfBadgers--;
            }
        }

        //once all badgers + rats have been spawned theres no need to keep calling this function
        if(currentWaveInfo.noOfBadgers == 0 && currentWaveInfo.noOfRats == 0)
            StopSpawning();
        
    }

    private void StartSpawning() 
    {
        //after 2 seconds will start spawning the enemy every set number of seconds
        InvokeRepeating("SpawnEnemy", 2.0f, spawnEverySeconds);
    }

    private void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }
}

[System.Serializable]
public class Wave
{
    public int noOfRats;
    public int noOfBadgers;
}