using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.ECS.Components
{
    public struct MovableComponent
    {
        public NavMeshAgent NavMeshAgent;
        public Animator Animator;
    }
}