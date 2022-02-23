using UnityEngine;
using Revamp;
using UnityEngine.Pool;

public class ShooterShip : EnemyBase
{
    [Header("Class Member Variable")]
    private float trailTime = 1.5f;

    [SerializeField] TrailRenderer trailPrefab;
    public TrailRenderer TrailPrefab
    {
        get { return trailPrefab; }
    }
    private IObjectPool<ShooterShip> shooterPool;

    #region Behaviour
    public override void ChildBehaviourInUpdate()
    {
        Vector2 movement = new Vector2(-1f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        bool enterTheFrame = transform.position.x <= 13f;
        if (enterTheFrame) trailPrefab.time = trailTime;
    }
    public override void ChildBehaviourWhenInvisible()
    {         
        shooterPool.Release(this);
    }
    public override void ChildBehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            var player = collision.GetComponent<PlayerStats>();
            player.Scoring(new ShooterShipOrigin());
        }
    }
    public override void ChildBehaviourOnDestroy()
    {
        // for removing from list or array
        // or any other function that need to run
        // if the object is destroyed
    }
    #endregion
    #region ObjectPool
    public void SetPool(IObjectPool<ShooterShip> receivedPool)
    {
        shooterPool = receivedPool;
    }
    public Vector2 SetSpawnPoint()
    {
        Vector2 newPosition = new Vector2(15f, UnityEngine.Random.Range(-6f, 6f));
        return newPosition;
    }
    #endregion
}
