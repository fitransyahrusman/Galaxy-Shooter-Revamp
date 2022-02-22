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

    private IObjectPool<KamikazeShip> kamikazePool;

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
        kamikazePool.Release(this);
    }
    public override void ChildBehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            var player = collision.GetComponent<PlayerStats>();
            player.Scoring(new KamikazeShipOrigin());
        }
    }
    public override void ChildBehaviourOnDestroy()
    {
        // for removing from list or array
        // or any other function that need to run
        // if the object is destroyed
    }
    #endregion

    public void SetPool(IObjectPool<KamikazeShip> receivedPool)
    {
        kamikazePool = receivedPool;
    }
    public Vector2 SetSpawnPoint()
    {
        Vector2 newPosition = new Vector2(15f, UnityEngine.Random.Range(-6f, 6f));
        return newPosition;
    }
}


