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
        [SerializeField] GameObject poolPrefab;
        [SerializeField] int spawnAmount;
    }
    [System.Serializable]
    public class Waves
    {
        [SerializeField] string waveName;
        public SpawnItem[] spawnItemArray;
    }
    public class TheSpawner : MonoBehaviour
    {
        int currentWave;

        [SerializeField] Waves[] waves;

        private List<GameObject> gameObjectsWithPoolList;
        private GameObject[] gameObjectsWithPoolArray;

        private void Update()
        {

        }
        private void ArrayMover()
        {

        }

    }
 }

