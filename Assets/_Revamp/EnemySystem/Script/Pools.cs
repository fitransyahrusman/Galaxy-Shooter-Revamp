using UnityEngine;
using UnityEngine.Pool;

public class Pools: MonoBehaviour
{
    [SerializeField] private KamikazeShip kamikazePrefab;

    private IObjectPool<KamikazeShip> kamikazePool;

    private void Awake()
    {
        kamikazePool = new ObjectPool<KamikazeShip>(
            CreateKamikaze,
            GetKamikaze,
            ReleaseKamikaze,
            DestroyKamikaze,
            defaultCapacity: 25
            ) ;
    }
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
        Destroy(kamikazeShip);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            kamikazePool.Get();
        }
    }
}
