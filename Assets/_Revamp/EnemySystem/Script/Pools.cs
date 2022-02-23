using UnityEngine;
using UnityEngine.Pool;

public class Pools: MonoBehaviour
{
    [SerializeField] private KamikazeShip kamikazePrefab;
    [SerializeField] private ShooterShip shooterPrefab;

    private IObjectPool<KamikazeShip> kamikazePool;
    private IObjectPool<ShooterShip> shooterPool;

    private void Awake()
    {
        kamikazePool = new ObjectPool<KamikazeShip>(
            CreateKamikaze,
            GetKamikaze,
            ReleaseKamikaze,
            DestroyKamikaze,
            defaultCapacity: 25
            ) ;
        shooterPool = new ObjectPool<ShooterShip>(
            CreateShooter,
            GetShooter,
            ReleaseShooter,
            DestroyShooter,
            defaultCapacity : 20
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
        Destroy(kamikazeShip);
    }
    #endregion
    #region ShooterShipAction
    ShooterShip CreateShooter()
    {
        var instance = Instantiate(shooterPrefab);
        instance.SetPool(shooterPool);
        return instance;
    }
    void GetShooter(ShooterShip shooterShip)
    {
        shooterShip.gameObject.SetActive(true);
        shooterShip.transform.position = shooterShip.SetSpawnPoint();
    }
    void ReleaseShooter(ShooterShip shooterShip)
    {
        shooterShip.TrailPrefab.time = 0 ;
        shooterShip.gameObject.SetActive(false);
    }
    void DestroyShooter(ShooterShip shooterShip)
    {
        Destroy(shooterShip);
    }
    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            kamikazePool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shooterPool.Get();
        }
    }   
}
