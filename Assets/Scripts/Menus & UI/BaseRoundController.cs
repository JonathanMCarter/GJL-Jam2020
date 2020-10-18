using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DresslikeaGnome.OhGnomes
{
    public class BaseRoundController : MonoBehaviour
    {
        
        [SerializeField] private GameObject ratPrefab;
        [SerializeField] private GameObject badgerPrefab;
        [SerializeField] private GameObject batPrefab;
        [SerializeField] private MainRoundController roundControllerObject;

        [SerializeField] private List<GameObject> spawnerLocations;
        [SerializeField] private GameObject EnemyContainerArray;

        private int currentWave = 0;
        private Wave currentWaveInfo;
        private bool checkEnemyArray = false;

        public float spawnEverySeconds = 10.0f;
        public List<Wave> waves;


        public GameObject[] enemiesPool;
        
        
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("start Round, waves: " + waves.Count);

            //autograb the arrays needed

            SpawnEnemies();

            RunWave();
        }

        // Update is called once per frame
        void Update()
        {
            //
            if(checkEnemyArray)
            {
                CheckEnemyArray();
            }
        }

        private void RunWave()
        {
            checkEnemyArray = false;

            //get the current wave
            currentWaveInfo = waves[currentWave];
            
            StartSpawning();
        }

        private void NextWave()
        {
            //incriment the round count
            currentWave++;

            //because of how arrays are counts (item 1 = array spot 0) have to look one below
            if (currentWave < waves.Count)
            {
                RunWave();
            }
            else
            {
                //completed the round!
                EndRound();
            }

        }

        private void EndWave()
        {
            //turn off the the array checker once the round has ended
            checkEnemyArray = !checkEnemyArray;
            //add a message forthe user

            NextWave();
        }

        private void EndRound()
        {
            roundControllerObject.EndRound();
        }

        private void SpawnEnemy()
        {
            //randomly decide where the enmies will come from
            int locationId = Random.Range(0, spawnerLocations.Count);
            int randomNumber = Random.Range(0, 3);

            //randomly decide which enemy to spawn IF theres enough left to spawn
            // Jonathan edit, made it run on MOD just for a better solution, MOD 3 checks to see how close to 3 it is for 0%3 = 0 and so on...
            // Also makes this expandable in the future should there be a need for more enemy types...
            if (randomNumber % 3 == 0)
            {
                if (currentWaveInfo.noOfRats > 0)
                {
                    for (int i = 0; i < enemiesPool.Length; i++)
                    {
                        if (!enemiesPool[i].activeInHierarchy && enemiesPool[i].name.Contains("Rat"))
                        {
                            enemiesPool[i].transform.position = spawnerLocations[locationId].transform.position;
                            enemiesPool[i].transform.rotation = transform.rotation;
                            enemiesPool[i].GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                            enemiesPool[i].GetComponent<BaseEnemyBehaviour>().ResetHealth();
                            enemiesPool[i].SetActive(true);
                            break;
                        }
                    }

                    //Instantiate(ratPrefab, 
                    //spawnerLocations[locationId].transform.position, 
                    //Quaternion.identity, 
                    //EnemyContainerArray.transform);

                    --currentWaveInfo.noOfRats;
                    --currentWaveInfo.numberOfEnemiesLeft;
                }
            }
            else if(randomNumber % 3 == 1)
            {
                if(currentWaveInfo.noOfBadgers > 0)
                {
                    for (int i = 0; i < enemiesPool.Length; i++)
                    {
                        if (!enemiesPool[i].activeInHierarchy && enemiesPool[i].name.Contains("Badger"))
                        {
                            enemiesPool[i].transform.position = spawnerLocations[locationId].transform.position;
                            enemiesPool[i].transform.rotation = Quaternion.identity;
                            enemiesPool[i].GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                            enemiesPool[i].GetComponent<BaseEnemyBehaviour>().ResetHealth();
                            enemiesPool[i].SetActive(true);
                            break;
                        }
                    }

                    //Instantiate(badgerPrefab, 
                    //spawnerLocations[locationId].transform.position, 
                    //Quaternion.identity, 
                    //EnemyContainerArray.transform);

                    --currentWaveInfo.noOfBadgers;
                    --currentWaveInfo.numberOfEnemiesLeft;
                }
            }
            else if (randomNumber % 3 == 2)
            {
                if (currentWaveInfo.noOfBats > 0)
                {
                    for (int i = 0; i < enemiesPool.Length; i++)
                    {
                        if (!enemiesPool[i].activeInHierarchy && enemiesPool[i].name.Contains("Bat"))
                        {
                            enemiesPool[i].transform.position = spawnerLocations[locationId].transform.position;
                            enemiesPool[i].transform.rotation = Quaternion.identity;
                            enemiesPool[i].GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                            enemiesPool[i].GetComponent<BaseEnemyBehaviour>().ResetHealth();
                            enemiesPool[i].SetActive(true);
                            break;
                        }
                    }

                    //Instantiate(badgerPrefab, 
                    //spawnerLocations[locationId].transform.position, 
                    //Quaternion.identity, 
                    //EnemyContainerArray.transform);

                    --currentWaveInfo.noOfBats;
                    --currentWaveInfo.numberOfEnemiesLeft;
                }
            }

            //once all badgers + rats have been spawned theres no need to keep calling this function
            if (currentWaveInfo.noOfBadgers.Equals(0) && currentWaveInfo.noOfRats.Equals(0) && currentWaveInfo.noOfBats.Equals(0))
            {
                StopSpawning();
                checkEnemyArray = true;
            }
            
        }

        /// <summary>
        /// Jonathan edited this so it would actually run, I don't destroy objects, just disable them...
        /// </summary>
        private void CheckEnemyArray()
        {
            if (HasRoundBeenDefeated())
            {
                EndWave();
            }
        }

        private void StartSpawning() 
        {
            //after 2 seconds will start spawning the enemy every set number of seconds
            InvokeRepeating("SpawnEnemy", 2.0f, spawnEverySeconds);
        }

        private void StopSpawning()
        {
            //stops spawning enemies
            CancelInvoke("SpawnEnemy");
        }


        /// <summary>
        /// Spawns the eneimes into the level in preperation for spawning them from their spawn points.
        /// </summary>
        private void SpawnEnemies()
        {
            int _amountToSpawn;
            int[] _ratsToSpawn = new int[4];
            int[] _badgersToSpawn = new int[4];
            int[] _batsToSpawn = new int[4];
            int[] _typeAmountsToSpawn = new int[3];

            for (int i = 0; i < waves.Count; i++)
            {
                _ratsToSpawn[i] = waves[i].noOfRats;
                _badgersToSpawn[i] = waves[i].noOfBadgers;
                _batsToSpawn[i] = waves[i].noOfBats;

                waves[i].numberOfEnemiesLeft = CalculateNumberOfEnemiesInWave(waves[i]);
            }

            // only spawn the max amount needed acroess all the waves...
            _ratsToSpawn[3] = Mathf.Max(_ratsToSpawn[0], _ratsToSpawn[1], _ratsToSpawn[2]);
            _badgersToSpawn[3] = Mathf.Max(_badgersToSpawn[0], _badgersToSpawn[1], _badgersToSpawn[2]);
            _batsToSpawn[3] = Mathf.Max(_batsToSpawn[0], _batsToSpawn[1], _batsToSpawn[2]);

            _typeAmountsToSpawn[0] = _ratsToSpawn[3];
            _typeAmountsToSpawn[1] = _badgersToSpawn[3];
            _typeAmountsToSpawn[2] = _batsToSpawn[3];

            _amountToSpawn = _ratsToSpawn[3] + _badgersToSpawn[3] + _batsToSpawn[3];

            enemiesPool = new GameObject[_amountToSpawn];

            for (int i = 0; i < _amountToSpawn; i++)
            {
                if (!_typeAmountsToSpawn[0].Equals(0))
                {
                    GameObject _go = Instantiate(ratPrefab, EnemyContainerArray.transform);
                    _go.name = "* (Pool) Rat Enemy *";
                    _go.SetActive(false);
                    enemiesPool[i] = _go;
                    _typeAmountsToSpawn[0] -= 1;
                }
                else if (!_typeAmountsToSpawn[1].Equals(0))
                {
                    GameObject _go = Instantiate(badgerPrefab, EnemyContainerArray.transform);
                    _go.name = "* (Pool) Badger Enemy *";
                    _go.SetActive(false);
                    enemiesPool[i] = _go;
                    _typeAmountsToSpawn[1] -= 1;
                }
                else if(!_typeAmountsToSpawn[2].Equals(0))
                {
                    GameObject _go = Instantiate(batPrefab, EnemyContainerArray.transform);
                    _go.name = "* (Pool) Bat Enemy *";
                    _go.SetActive(false);
                    enemiesPool[i] = _go;
                    _typeAmountsToSpawn[2] -= 1;
                }
                else
                {
                    Debug.Log("it run out early???");
                }
            }
        }

        /// <summary>
        /// Gets the amount of enemies in the wave
        /// </summary>
        /// <param name="toCheck">Wave to check</param>
        /// <returns>the amount of enemies in the wave</returns>
        private int CalculateNumberOfEnemiesInWave(Wave toCheck)
        {
            return toCheck.noOfRats + toCheck.noOfBadgers + toCheck.noOfBats;
        }


        /// <summary>
        /// Checks to see if the round has been completed
        /// </summary>
        /// <returns>ture if it has, false if not</returns>
        private bool HasRoundBeenDefeated()
        {
            int numberDefeaded = 0;

            for (int i = 0; i < enemiesPool.Length; i++)
            {
                if (!enemiesPool[i].activeInHierarchy)
                {
                    ++numberDefeaded;
                }
            }

            if (numberDefeaded.Equals(EnemyContainerArray.transform.childCount))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int noOfRats;
        public int noOfBadgers;
        public int noOfBats;
        public int numberOfEnemiesLeft;
    }
}
