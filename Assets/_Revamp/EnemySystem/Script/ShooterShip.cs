using UnityEngine;
using Revamp;
using System.Collections;

public class ShooterShip : EnemyBase
{
    [Header("Class Member Variable")]
    [SerializeField]
    TrailRenderer trailPrefab;
    public override void ChildMovementBehaviour()
    {
        Vector2 movement = new Vector2(-1f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    public override void ChildBehaviourWhenInvisible()
    {
        Vector2 newPosition = new Vector2(13.5f, UnityEngine.Random.Range(-6f, 6f));
        transform.position = newPosition;
        StartCoroutine(ResettingTrail());
    }
    public override void ChildBehaviourWhenVisible()
    {
        //
    }
    public override void ChildBehaviourWhenEnterTrigger2D(Collider2D collision)
    {
        //
    }
    IEnumerator ResettingTrail()
    {
        var trailTime = trailPrefab.time;
        trailPrefab.time = 0;
        yield return new WaitForSeconds(0.25f);
        trailPrefab.time = trailTime;
    }
}
