using UnityEngine;
using UnityEngine.Pool;

namespace Revamp.Spawn
{
    public class RotatingRockPool : MonoBehaviour
    {
        [SerializeField] private RotatingRock rotatingRockPrefab;
        [SerializeField] private TheSpawner theSpawner;

        internal IObjectPool<RotatingRock> rotatingRockPool;

        private void Awake()
        {
            rotatingRockPool = new ObjectPool<RotatingRock>(
            CreateRotatingRock,
            GetRotatingRock,
            ReleaseRotatingRock,
            DestroyRotatingRock,
            maxSize: 10
            );
        }
        #region RotatingRockAction
        RotatingRock CreateRotatingRock()
        {
            var instance = Instantiate(rotatingRockPrefab);
            instance.SetPool(rotatingRockPool);
            return instance;
        }
        internal void GetRotatingRock(RotatingRock rotatingRock)
        {
            rotatingRock.gameObject.SetActive(true);
            rotatingRock.transform.position = rotatingRock.SetSpawnPoint();
        }
        void ReleaseRotatingRock(RotatingRock rotatingRock)
        {
            rotatingRock.gameObject.SetActive(false);
        }
        void DestroyRotatingRock(RotatingRock rotatingRock)
        {
            Destroy(rotatingRock.gameObject);
        }
        #endregion
        internal void GetRotatingRockEvent()
        {
            rotatingRockPool.Get();
        }
        private void OnEnable()
        {
            theSpawner.rotatingRockSpawnEvent += GetRotatingRockEvent;
        }
        private void OnDisable()
        {
            theSpawner.rotatingRockSpawnEvent -= GetRotatingRockEvent;
        }
    }
}

