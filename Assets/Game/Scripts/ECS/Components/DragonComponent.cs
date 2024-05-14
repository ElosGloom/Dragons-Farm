using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.ECS.Components
{
    public struct DragonComponent
    {
        public NavMeshAgent NavMeshAgent;
        public Animator Animator;
        public DragonType Type;
    }
}