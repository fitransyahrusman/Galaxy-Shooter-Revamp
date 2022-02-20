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
            ChildMovementBehaviour();
        }
        private void OnBecameInvisible()
        {
            ChildBehaviourWhenInvisible();
        }
        private void OnBecameVisible()
        {
            ChildBehaviourWhenVisible();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ChildBehaviourWhenEnterTrigger2D(collision);
            if (collision.tag == "Laser" || collision.tag == "Player")
            {
                Explosion();
                Destroy(gameObject, 0.2f);
            }
        }
        private void Explosion()
        {
            var thisPosition = transform.position;
            var instance = Instantiate(explosionParticle, thisPosition, Quaternion.identity);
            instance.Play();
        }
        private void OnDestroy()
        {
            ChildBehaviourOnDestroy();
        }
        public abstract void ChildMovementBehaviour();
        public abstract void ChildBehaviourWhenInvisible();
        public abstract void ChildBehaviourWhenVisible();
        public abstract void ChildBehaviourWhenEnterTrigger2D(Collider2D collision);
        public abstract void ChildBehaviourOnDestroy();
       

    }
}

