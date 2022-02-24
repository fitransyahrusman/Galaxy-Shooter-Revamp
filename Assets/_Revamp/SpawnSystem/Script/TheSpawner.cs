using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;
using System;

namespace Revamp.Spawn
{
    [System.Serializable]
    public class Waves
    {
        [SerializeField] string waveName;
        [SerializeField] int spawnAmountOne;
        [SerializeField] int spawnAmountTwo;
        [SerializeField] int spawnAmountThree;
        public List<GameObject> listWithPool;
        public GameObject[] arrayWithPool;
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

    }
 }

