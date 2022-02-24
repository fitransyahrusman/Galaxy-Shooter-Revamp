using UnityEngine;
using System.Collections;

namespace Revamp.Spawn
{
    public class SpawnMachine : MonoBehaviour
    {
        public static SpawnMachine Instance;

        float fastDynamicInterval;
        float slowDynamicInterval;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        private void Update()
        {
            
        }
        #region Spawning
        internal void SpawnStart()
        {
            StartCoroutine(SpawnObjectOne());
            StartCoroutine(SpawnObjectTwo());
        }
        IEnumerator SpawnObjectOne()
        {
            yield return null;
        }
        IEnumerator SpawnObjectTwo()
        {
            yield return null;
        }
        #endregion
        #region Interval
        float FastIntervalCreator()
        {
            fastDynamicInterval = 1;
            return fastDynamicInterval;
        }
        float FastIntervalGetter()
        {
            float fastInterval = fastDynamicInterval;
            return fastInterval;
        }
        float SlowIntervalCreator()
        {
            slowDynamicInterval = 1;
            return slowDynamicInterval;
        }
        float SlowIntervalGetter()
        {
            float slowInterval = slowDynamicInterval;
            return slowInterval;
        }
        #endregion



    }
}

