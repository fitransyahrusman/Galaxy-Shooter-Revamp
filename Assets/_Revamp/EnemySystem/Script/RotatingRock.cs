using UnityEngine;
using Revamp;

public class RotatingRock : EnemyBase
{
    [Header("Class Member Variable")]
    [SerializeField]
    Rigidbody2D myRigidbody;
    public override void MovementBehaviour()
    {
        myRigidbody.AddTorque(Random.Range(-1f, 1f));
        myRigidbody.AddRelativeForce(new Vector2(0,0.5f));
    }
    public override void BehaviourWhenInvisible()
    {
        // just destroy it, it will come in a wave in gameplay
        Destroy(gameObject);
    }
}
