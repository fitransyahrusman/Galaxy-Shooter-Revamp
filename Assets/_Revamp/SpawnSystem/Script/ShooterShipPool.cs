using UnityEngine;
using UnityEngine.Pool;

namespace Revamp.Spawn
{
    public class ShooterShipPool : MonoBehaviour
    {
        [SerializeField] private ShooterShip shooterPrefab;

        internal IObjectPool<ShooterShip> shooterPool;

        private void Awake()
        {
            shooterPool = new ObjectPool<ShooterShip>(
                CreateShooter,
                GetShooter,
                ReleaseShooter,
                DestroyShooter,
                maxSize: 15
                );
        }
        #region ShooterShipAction
        ShooterShip CreateShooter()
        {
            var instance = Instantiate(shooterPrefab);
            instance.SetPool(shooterPool);
            return instance;
        }
        internal void GetShooter(ShooterShip shooterShip)
        {
            shooterShip.gameObject.SetActive(true);
            shooterShip.transform.position = shooterShip.SetSpawnPoint();
        }
        void ReleaseShooter(ShooterShip shooterShip)
        {
            shooterShip.TrailPrefab.time = 0;
            shooterShip.gameObject.SetActive(false);
        }
        void DestroyShooter(ShooterShip shooterShip)
        {
            Destroy(shooterShip.gameObject);
        }
        #endregion
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                shooterPool.Get();
            }
        }
    }   
}

