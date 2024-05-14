using UnityEngine;

namespace Game.Scripts.Utils
{
    public static class RandomRotation
    {
        public static Quaternion GetRandomRotation()
        {
            float randomRotationY = Random.Range(0, 360);

            var randomRotation = Quaternion.Euler(0, randomRotationY, 0);
            return randomRotation;
        }
    }
}