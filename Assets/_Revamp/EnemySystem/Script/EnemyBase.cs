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

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ChildBehaviourWhenEnterTrigger2D(collision);
            // if tag is player :
            // playing particle system prefab in each derived class
            // destroy object derived classs

        }
        public abstract void ChildMovementBehaviour();
        public abstract void ChildBehaviourWhenInvisible();
        public abstract void ChildBehaviourWhenVisible();
        public abstract void ChildBehaviourWhenEnterTrigger2D(Collider2D collision);
       

    }
}

