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

        public Waves(Waves newWaves)
        {
            waveName = newWaves.waveName;
            spawnItems = newWaves.spawnItems;
        }
    }

    public class TheSpawner : MonoBehaviour
    {
        int currentWavesIndex;

        [SerializeField] private SpawnMachine spawnMachine;

        [SerializeField] List<Waves> waves;

        //Waves currentWaves;

        public event Action kamikazeSpawnEvent;
        public event Action shooterSpawnEvent;
        public event Action rotatingRockSpawnEvent;

        private void Update()
        {
            //currentWaves = new Waves(waves[currentWavesIndex]);
            if (Input.GetKeyDown(KeyCode.U))
            {
                if (CurrentWaveExist() == true)
                {
                    // run the current waves
                    Debug.Log("Current waves : " + currentWavesIndex);
                    if (currentWavesIndex >= waves.Count) return;
                    for (int i = 0; i < waves[currentWavesIndex].spawnItems.Count; i++)
                    {
                        var gameObject = waves[currentWavesIndex].spawnItems[i].enemyPrefab;
                        if (HasComponent<KamikazeShip>(gameObject))
                        {
                            Debug.Log("It was kamikaze!");
                            if (kamikazeSpawnEvent != null)
                            {
                                Debug.Log("Post 1");
                                spawnMachine.SpawnStart(kamikazeSpawnEvent, waves[currentWavesIndex].spawnItems[i].spawnAmount);
                            }
                        }
                        else if (HasComponent<ShooterShip>(gameObject))
                        {
                            Debug.Log("It was shooter ship!");
                            if (shooterSpawnEvent != null)
                            {
                                Debug.Log("Post 2");
                                spawnMachine.SpawnStart(shooterSpawnEvent, waves[currentWavesIndex].spawnItems[i].spawnAmount);
                            }
                        }
                        else if (HasComponent<RotatingRock>(gameObject))
                        {
                            Debug.Log("It was RotatingRock");
                            if (rotatingRockSpawnEvent != null)
                            {
                                Debug.Log("Post 3");
                                spawnMachine.SpawnStart(rotatingRockSpawnEvent, waves[currentWavesIndex].spawnItems[i].spawnAmount);
                            }
                        }
                        else
                        {
                            Debug.Log("Unidentified Enemy!");
                        }
                    }


                }
                else if (CurrentWaveExist() == false)
                {
                    Debug.Log("No more waves");
                }
                currentWavesIndex++;
            }
            
        }
        private static bool HasComponent<T>(GameObject obj)
        {
            return obj.GetComponent<T>() != null;
        }
        private bool CurrentWaveExist()
        {
            
            if (currentWavesIndex >= waves.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
                
            
        }
    }
 }

