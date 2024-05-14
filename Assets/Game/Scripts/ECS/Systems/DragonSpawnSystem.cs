using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.ECS.Monobehaviours;
using Game.Scripts.Utils;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class DragonSpawnSystem : IEcsRunSystem
    {
        private EcsFilter<ReadyToBornComponent> _readyToBornFilter;
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var i in _readyToBornFilter)
            {
                var dragonEntity = _readyToBornFilter.GetEntity(i);
                ref var readyToBornComponent = ref dragonEntity.Get<ReadyToBornComponent>();

                DragonView dragonView = DragonFactory.CreateDragon(_staticData,
                    readyToBornComponent.Type,
                    readyToBornComponent.Position,
                    RandomRotation.GetRandomRotation());
                
                ref var dragonComponent = ref dragonEntity.Get<DragonComponent>();
                ref var foodConsumerComponent = ref dragonEntity.Get<FoodConsumerComponent>();
                foodConsumerComponent.FoodAmountToCreateEgg = dragonView.foodAmountToCreateEgg;
                dragonComponent.NavMeshAgent = dragonView.navMeshAgent;
                dragonComponent.Animator = dragonView.animator;
                dragonComponent.Type = readyToBornComponent.Type;
                _staticData.DragonsStats.TryGetValue(readyToBornComponent.Type, out var stats);
                dragonComponent.EggMaterial = stats.eggMaterial;
                
                dragonEntity.Del<ReadyToBornComponent>();
                Debug.Log($" Dragon created! Type: {dragonComponent.Type} Food: {foodConsumerComponent.FoodAmountToCreateEgg}");
            }
           
            
        }
    }
}