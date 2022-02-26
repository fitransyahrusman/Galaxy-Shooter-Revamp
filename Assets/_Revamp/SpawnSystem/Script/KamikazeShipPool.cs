using UnityEngine;
using UnityEngine.Pool;

namespace Revamp.Spawn
{
    public class KamikazeShipPool : MonoBehaviour
    {
        [SerializeField] private KamikazeShip kamikazePrefab;
        [SerializeField] private TheSpawner theSpawner;
                        
        private IObjectPool<KamikazeShip> kamikazePool;       
        
        private void Awake()
        {
            kamikazePool = new ObjectPool<KamikazeShip>(
                CreateKamikaze,
                GetKamikaze,
                ReleaseKamikaze,
                DestroyKamikaze,
                maxSize: 20
                );  
        }
        #region KamikazePoolAction
        KamikazeShip CreateKamikaze()
        {
            var instance = Instantiate(kamikazePrefab);
            instance.SetPool(kamikazePool);
            return instance;
        }
        void GetKamikaze(KamikazeShip kamikazeShip)
        {
            kamikazeShip.gameObject.SetActive(true);
            kamikazeShip.transform.position = kamikazeShip.SetSpawnPoint();
        }
        void ReleaseKamikaze(KamikazeShip kamikazeShip)
        {
            kamikazeShip.TrailPrefab.time = 0;
            kamikazeShip.gameObject.SetActive(false);
        }
        void DestroyKamikaze(KamikazeShip kamikazeShip)
        {
            Destroy(kamikazeShip.gameObject);
        }
        internal void GetKamikazeEvent()
        {
            kamikazePool.Get();
        }
        #endregion
        private void OnEnable()
        {
            theSpawner.kamikazeSpawnEvent += GetKamikazeEvent;
        }
        private void OnDisable()
        {
            theSpawner.kamikazeSpawnEvent -= GetKamikazeEvent;
        }
    }
}

