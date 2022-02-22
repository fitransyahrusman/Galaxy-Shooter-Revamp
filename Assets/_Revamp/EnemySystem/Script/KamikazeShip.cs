using System.Threading.Tasks;
using UnityEngine;
using Revamp;
using UnityEngine.Pool;

public class KamikazeShip : EnemyBase
{
    [Header("Class Member Variable")]
    private float trailTime = 0.8f;
    
    [SerializeField] TrailRenderer trailPrefab;

    private IObjectPool<KamikazeShip> kamikazePool;

    #region Behaviour
    public override void ChildMovementBehaviour()
    {
        Vector2 movement = new Vector2(-1f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    public override void ChildBehaviourWhenInvisible()
    {
       
        Vector2 newPosition = new Vector2(13.5f, UnityEngine.Random.Range(-6f, 6f));
        transform.position = newPosition;
        ResettingTrail();
        kamikazePool.Release(this);
    }
    public override void ChildBehaviourWhenVisible()
    {
        if (trailPrefab != null) trailPrefab.time = trailTime;
        kamikazePool.Get(); // call this from spawner
    }
    public override void ChildBehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            var player = collision.GetComponent<PlayerStats>();
            player.Scoring(new KamikazeShipOrigin());
        }
    }
    async void ResettingTrail()
    {
        trailPrefab.time = 0;
        await Task.Delay(1000);
    }
    public override void ChildBehaviourOnDestroy()
    {
        //
    }
    #endregion

    public void SetPool(IObjectPool<KamikazeShip> receivedPool)
    {
        kamikazePool = receivedPool;
    }
}


