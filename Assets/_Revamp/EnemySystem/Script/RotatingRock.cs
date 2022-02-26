using UnityEngine;
using Revamp;
using UnityEngine.Pool;

public class RotatingRock : EnemyBase
{
    [Header("Class Member Variable")]
    [SerializeField] Rigidbody2D myRigidbody;
    private IObjectPool<RotatingRock> rotatingRockPool;
    #region Behaviour
    public override void ChildBehaviourInUpdate()
    {
        myRigidbody.AddTorque(Random.Range(-1f, 1f));
        myRigidbody.AddRelativeForce(new Vector2(0,0.5f));
    }
    public override void ChildBehaviourWhenInvisible()
    {
        if (rotatingRockPool != null) rotatingRockPool.Release(this);
    }
    public override void ChildBehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            var player = collision.GetComponent<PlayerStats>();
            player.Scoring(new RotatingRockOrigin());
            if (rotatingRockPool != null) rotatingRockPool.Release(this);
        }
        else if (collision.tag == "Player")
        {
            base.Explosion();
            if (rotatingRockPool != null) rotatingRockPool.Release(this);
        }
    }
    public override void ChildBehaviourOnDestroy()
    {
        //
    }
    #endregion
    #region ObjectPool
    public void SetPool(IObjectPool<RotatingRock> receivedPool)
    {
        rotatingRockPool = receivedPool;
    }
    #endregion

}
