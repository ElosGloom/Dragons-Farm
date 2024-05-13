using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.ECS.Components
{
    public struct DragonComponent
    {
        public NavMeshAgent NavMeshAgent;
        public float MovementSpeed;
        public float EatingTimeLeft;
        public Animator Animator;
        public DragonType Type;
        public int FoodCollected;
        public int FoodAmountToCreateEgg;

    }
}