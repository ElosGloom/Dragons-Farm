using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.ECS.Monobehaviours;
using Game.Scripts.Utils;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class TestSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            var dragonEntity = _ecsWorld.NewEntity();
            ref var dragonComponent = ref dragonEntity.Get<DragonComponent>();
            ref var foodConsumerComponent = ref dragonEntity.Get<FoodConsumerComponent>();

            var dragonType = Utils.Enum.GetRandom<DragonType>();

            DragonView dragonView = DragonFactory.CreateDragon(_staticData, dragonType,
                RandomPosition.GetRandomSpawnPosition(_sceneData), RandomRotation.GetRandomRotation());
            foodConsumerComponent.FoodAmountToCreateEgg = dragonView.foodAmountToCreateEgg;
            dragonComponent.NavMeshAgent = dragonView.navMeshAgent;
            dragonComponent.Animator = dragonView.animator;
            dragonComponent.Type = dragonType;

            Debug.Log(
                $" Dragon created! Type: {dragonComponent.Type} Food: {foodConsumerComponent.FoodAmountToCreateEgg}");
        }
    }
}