using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;
using System;

namespace Revamp.Spawn
{
    [System.Serializable]
    public class SpawnItem
    {
        [SerializeField] string objectName;
        [SerializeField] internal int spawnAmount;
        [SerializeField] internal GameObject enemyPrefab;
    }
    [System.Serializable]
    public class Waves
    {
        [SerializeField] string waveName;
        public List<SpawnItem> spawnItems;
    }

    public class TheSpawner : MonoBehaviour
    {
        int currentWaves;

        [SerializeField] private SpawnMachine spawnMachine;

        [SerializeField] List<Waves> waves;

        public event Action kamikazeSpawn;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                    for (int i = 0; i < waves[currentWaves].spawnItems.Count; i++)
                    {                        
                        var gameObject = waves[currentWaves].spawnItems[i].enemyPrefab;
                        if (HasComponent<KamikazeShip>(gameObject))
                        {
                            Debug.Log("It was kamikaze!");
                            if (kamikazeSpawn != null)
                            {
                                spawnMachine.SpawnStart(kamikazeSpawn, waves[currentWaves].spawnItems[i].spawnAmount);
                                currentWaves++;
                            }
                        }
                        else if (HasComponent<ShooterShip>(gameObject))
                        {
                            Debug.Log("It was shooter ship!");
                        }
                        else if (HasComponent<RotatingRock>(gameObject))
                        {
                            Debug.Log("It was RotatingRock");
                        }
                        else Debug.Log("Unidentified enemy type");
                        //kamikazeSpawn(); // trigger the event
                    }                   
            }
            if (CurrentWaveExist())
            {
                // run the current waves
            }
            else if (!CurrentWaveExist())
            {
                // no more waves
            }
        }
        private static bool HasComponent<T>(GameObject obj)
        {
            return obj.GetComponent<T>() != null;
        }
        private bool CurrentWaveExist()
        {
            if (currentWaves == waves.Count - 1)
            {
                return false;
            }
            else return true;
        }
    }
 }

