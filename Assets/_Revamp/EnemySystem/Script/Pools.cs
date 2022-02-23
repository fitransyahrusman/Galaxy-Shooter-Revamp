using UnityEngine;
using UnityEngine.Pool;

public class Pools: MonoBehaviour
{
    [SerializeField] private KamikazeShip kamikazePrefab;
    [SerializeField] private ShooterShip shooterPrefab;
    [SerializeField] private RotatingRock rotatingRockPrefab;

    private IObjectPool<KamikazeShip> kamikazePool;
    private IObjectPool<ShooterShip> shooterPool;
    private IObjectPool<RotatingRock> rotatingRockPool;

    private void Awake()
    {
        kamikazePool = new ObjectPool<KamikazeShip>(
            CreateKamikaze,
            GetKamikaze,
            ReleaseKamikaze,
            DestroyKamikaze,
            maxSize : 20
            ) ;
        shooterPool = new ObjectPool<ShooterShip>(
            CreateShooter,
            GetShooter,
            ReleaseShooter,
            DestroyShooter,
            maxSize : 15
            );
            rotatingRockPool = new ObjectPool<RotatingRock>(
            CreateRotatingRock,
            GetRotatingRock,
            ReleaseRotatingRock,
            DestroyRotatingRock,
            maxSize : 10
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
        Destroy(shooterShip.gameObject);
    }
    #endregion
    #region RotatingRockAction
    RotatingRock CreateRotatingRock()
    {
        var instance = Instantiate(rotatingRockPrefab);
        instance.SetPool(rotatingRockPool);
        return instance ;
    }
    void GetRotatingRock(RotatingRock rotatingRock)
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
        if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            rotatingRockPool.Get();
        }
    }   
}
