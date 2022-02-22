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
            maxSize : 10
            );
    }
    KamikazeShip CreateKamikaze()
    {
        var instance = Instantiate(kamikazePrefab);
        kamikazePrefab.SetPool(kamikazePool);
        return instance;
    }
    void GetKamikaze(KamikazeShip kamikazeShip)
    {
        kamikazeShip.gameObject.SetActive(true);
    }
    void ReleaseKamikaze(KamikazeShip kamikazeShip)
    {
        kamikazeShip.gameObject.SetActive(false);
    }
    void DestroyKamikaze(KamikazeShip kamikazeShip)
    {
        Destroy(kamikazeShip);
    }
}
