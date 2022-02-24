using UnityEngine;

namespace Revamp
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField]
        private protected float speed;
       
        [SerializeField] 
        private protected ParticleSystem explosionParticle;

        private void Update()
        {
            ChildBehaviourInUpdate();
        }
        private void OnBecameInvisible()
        {
            ChildBehaviourWhenInvisible();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ChildBehaviourWhenEnterTrigger2D(collision);
        }
        private void OnDestroy() // not used for now but lets keep it for future need
        {
            ChildBehaviourOnDestroy();
        }
        public abstract void ChildBehaviourInUpdate();
        public abstract void ChildBehaviourWhenInvisible();
        public abstract void ChildBehaviourWhenEnterTrigger2D(Collider2D collision);
        public abstract void ChildBehaviourOnDestroy();

        public virtual void Explosion() //possible for different explosion
        {
            var thisPosition = transform.position;
            var instance = Instantiate(explosionParticle, thisPosition, Quaternion.identity);
            instance.Play();
        }
        public virtual Vector2 SetSpawnPoint() // possible for different spawnpoint
        {
            Vector2 newPosition = new Vector2(15f, UnityEngine.Random.Range(-6f, 6f));
            return newPosition;
        }


       

    }
}

