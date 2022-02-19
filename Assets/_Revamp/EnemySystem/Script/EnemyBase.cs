using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revamp
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField]
        private protected float speed;

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
        public abstract void MovementBehaviour();
        public abstract void BehaviourWhenInvisible();

    }
}

