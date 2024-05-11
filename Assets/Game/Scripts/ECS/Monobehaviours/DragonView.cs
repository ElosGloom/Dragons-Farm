using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts
{
    public class DragonView : MonoBehaviour
    {
        public Renderer[] renderers;
        public NavMeshAgent navMeshAgent;
        public Animator animator;
        public float dragonMovementSpeed;
        public float eatingTime;
    }
}