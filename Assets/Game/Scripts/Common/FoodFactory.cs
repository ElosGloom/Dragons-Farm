using FPS.Pool;
using Game.Scripts.ECS.Monobehaviours;
using UnityEngine;

namespace Game.Scripts.Common
{
    public static class FoodFactory
    {
        public static Transform CreateFood(FoodType foodType, Vector3 spawnPosition)
        {
            
             var foodTransform =   FluffyPool.Get<Transform>(foodType.ToString());
             foodTransform.position = spawnPosition;
            return foodTransform;
        }
    }
}