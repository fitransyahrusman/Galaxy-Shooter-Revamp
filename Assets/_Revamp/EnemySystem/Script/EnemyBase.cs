using System;
using UnityEngine;


namespace Revamp
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField]
        private protected float speed;
        private protected int score;

        [SerializeField] 
        private protected GameObject explosionPrefab;

        private void Update()
        {
            MovementBehaviour();
        }
        private void OnBecameInvisible()
        {
            BehaviourWhenInvisible();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollision(collision);
        }

        public abstract void MovementBehaviour();
        public abstract void BehaviourWhenInvisible();
        public abstract void OnCollision(Collision2D collision);
       

    }
}

