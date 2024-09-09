using System;
using Game.Scripts.Pool;
using UnityEngine;

namespace Game.Scripts.Common
{
    public class Destroyer : MonoBehaviour
    {
        
        [SerializeField] private Collider ground;

        private void OnCollisionEnter(Collision other)
        {
            PoolObjects.ReturnToPool(other.gameObject);
        }
    }
}