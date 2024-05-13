using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.ECS.Monobehaviours
{
    public class DragonView : MonoBehaviour
    {
        public Renderer[] renderers;
        public NavMeshAgent navMeshAgent;
        public Animator animator;
        public float dragonMovementSpeed;
        public float eatingTime;
        public int foodAmountToCreateEgg;
        public DragonType type;

    }
}