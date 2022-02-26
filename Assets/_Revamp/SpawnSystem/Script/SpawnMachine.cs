using UnityEngine;
using System.Collections;

namespace Revamp.Spawn
{
    public class SpawnMachine : MonoBehaviour
    {
        public static SpawnMachine Instance;

        [Header("Fast Interval Setting")]
        [Tooltip("Starting point of the dynamic Interval")]
        [SerializeField] float fastSpawnerRateFloor = 1;
        [Tooltip("Add this and your Rate Floor, the total would be your Ceiling")]
        [SerializeField] float fastSpawnerRateCeil = 2;
        [Tooltip("More bigger this, more slower the oscillator")]
        [SerializeField] [Range(1, 5)] float fastSpawnerPeriod = 2f;

        [Header("Slow Interval Setting")]
        [Tooltip("Starting point of the dynamic Interval")]
        [SerializeField] float slowSpawnerRateFloor = 1;
        [Tooltip("Add this and your Rate Floor, the total would be your Ceiling")]
        [SerializeField] float slowSpawnerRateCeil = 4;
        [Tooltip("More bigger this, more slower the oscillator")]
        [SerializeField] [Range(1, 5)] float slowSpawnerPeriod = 2f;

        private float fastSinWave;
        [Header("Fast Interval")]
        [SerializeField][Range(0, 10)] float fastDynamicIntervalResult;

        private float slowSinWave;
        [Header("Slow Interval")]
        [SerializeField][Range(0, 10)] float slowDynamicIntervalResult;
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
            FastIntervalCreator(fastSpawnerRateFloor, fastSpawnerRateCeil, fastSpawnerPeriod);
            SlowIntervalCreator(slowSpawnerRateFloor, slowSpawnerRateCeil, slowSpawnerPeriod);
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
        float FastIntervalCreator(float startPoint, float endPoint, float period)
        {
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 2f;
            float rawSinwave = Mathf.Sin(cycles * tau);

            fastSinWave = (rawSinwave + startPoint);
            fastDynamicIntervalResult = (fastSinWave * endPoint) / 2f;
            return fastDynamicIntervalResult;
        }
        float FastIntervalGetter()
        {
            float fastInterval = fastDynamicIntervalResult;
            return fastInterval;
        }
        float SlowIntervalCreator(float startPoint, float endPoint, float period)
        {
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 2f;
            float rawSinwave = Mathf.Sin(cycles * tau);

            slowSinWave = (rawSinwave + startPoint);
            slowDynamicIntervalResult = (slowSinWave * endPoint) / 2f;
            return slowDynamicIntervalResult;
        }
        float SlowIntervalGetter()
        {
            float slowInterval = slowDynamicIntervalResult;
            return slowInterval;
        }
        #endregion



    }
}

