using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.ECS.Components
{
    public struct DragonComponent
    {
        public NavMeshAgent DragonNavMeshAgent;
        public float MovementSpeed;
        public float EatingTimeLeft;
        public Animator Animator;

    }
}