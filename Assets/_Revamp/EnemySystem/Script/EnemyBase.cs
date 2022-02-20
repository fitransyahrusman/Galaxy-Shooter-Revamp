using System;
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
            MovementBehaviour();
        }
        private void OnBecameInvisible()
        {
            BehaviourWhenInvisible();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            BehaviourWhenEnterTrigger2D(collision);
            // if tag is player :
            // playing particle system prefab in each derived class
            // destroy object derived classs

        }
        public abstract void MovementBehaviour();
        public abstract void BehaviourWhenInvisible();
        public abstract void BehaviourWhenEnterTrigger2D(Collider2D collision);
       

    }
}

