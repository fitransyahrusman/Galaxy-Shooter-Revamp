using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revamp.Spawn
{
    public class ManualSpawner : MonoBehaviour
    {
        [SerializeField] KamikazeShipPool kamikazePool;
        [SerializeField] ShooterShipPool shooterPool;
        [SerializeField] RotatingRockPool rockPool;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                kamikazePool.GetKamikazeEvent();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                shooterPool.GetShooterEvent();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                rockPool.GetRotatingRockEvent();

            }
        }
    }
}

