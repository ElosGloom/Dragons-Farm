using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.ECS
{
    public struct DragonComponent
    {
        public NavMeshAgent dragonNavMeshAgent;
        public float movementSpeed;
        public Transform targetPositon;

    }
}