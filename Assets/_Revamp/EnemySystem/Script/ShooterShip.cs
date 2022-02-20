using UnityEngine;
using Revamp;

public class ShooterShip : EnemyBase
{
    public override void MovementBehaviour()
    {
        Vector2 movement = new Vector2(-1f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    public override void BehaviourWhenInvisible()
    {
        // warping to the right side of the screen
        transform.position = new Vector2(13.5f, UnityEngine.Random.Range(-6f, 6f));
    }
    public override void BehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}
