using UnityEngine;
using Revamp;

public class ShooterShip : EnemyBase
{
    private ShooterShip ()
    {
        score = 200;
    }
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
    public override void OnCollision(Collision2D collision)
    {
        
    }
}
