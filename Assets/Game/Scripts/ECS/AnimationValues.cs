using UnityEngine;

namespace Game.Scripts.ECS
{
    public static class AnimationValues
    {
        public static readonly int Run = Animator.StringToHash("Run");
        public static readonly int Eat = Animator.StringToHash("Eat");
        public static readonly int Idle = Animator.StringToHash("Idle");
    }
}