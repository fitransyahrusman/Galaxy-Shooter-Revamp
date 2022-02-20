using UnityEngine;
using Revamp;

public class RotatingRock : EnemyBase
{
    [Header("Class Member Variable")]
    [SerializeField]
    Rigidbody2D myRigidbody;
  
    public override void ChildMovementBehaviour()
    {
        myRigidbody.AddTorque(Random.Range(-1f, 1f));
        myRigidbody.AddRelativeForce(new Vector2(0,0.5f));
    }
    public override void ChildBehaviourWhenInvisible()
    {
        Destroy(gameObject);
    }
    public override void ChildBehaviourWhenVisible()
    {
        //
    }
    public override void ChildBehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            var player = collision.GetComponent<PlayerStats>();
            player.Scoring(new RotatingRockOrigin());
        }
    }
    public override void ChildBehaviourOnDestroy()
    {
        //
    }

}
