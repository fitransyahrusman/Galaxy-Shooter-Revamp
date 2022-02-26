using System.Threading.Tasks;
using UnityEngine;
using Revamp;
using UnityEngine.Pool;

public class KamikazeShip : EnemyBase
{
    [Header("Class Member Variable")]
    private float trailTime = 0.8f;

    [SerializeField] TrailRenderer trailPrefab;
    public TrailRenderer TrailPrefab
    {
        get { return trailPrefab; }
    }
    public IObjectPool<KamikazeShip> kamikazePool;

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
        if (kamikazePool != null) kamikazePool.Release(this);
    }
    public override void ChildBehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            var player = collision.GetComponent<PlayerStats>();
            player.Scoring(new KamikazeShipOrigin());
            if (kamikazePool != null) kamikazePool.Release(this);
        }
        else if (collision.tag == "Player")
        {
            base.Explosion();
            if (kamikazePool != null) kamikazePool.Release(this);
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
    public void SetPool(IObjectPool<KamikazeShip> receivedPool)
    {
        kamikazePool = receivedPool;
    }
    #endregion
}


