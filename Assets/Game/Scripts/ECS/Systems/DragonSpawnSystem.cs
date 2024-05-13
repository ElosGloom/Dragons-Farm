using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.ECS.Monobehaviours;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class DragonSpawnSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            var dragonEntity = _ecsWorld.NewEntity();
            ref var dragonComponent = ref dragonEntity.Get<DragonComponent>();
            
            var dragonType = Utils.Enum.GetRandom<DragonType>();

            DragonView dragonView = DragonFactory.CreateDragon(_staticData, _sceneData,dragonType);
            dragonComponent.FoodAmountToCreateEgg = dragonView.foodAmountToCreateEgg;
            dragonComponent.NavMeshAgent = dragonView.navMeshAgent;
            dragonComponent.Animator = dragonView.animator;
            dragonComponent.Type = dragonView.type;
            Debug.Log($" Dragon created! Type: {dragonComponent.Type} Food: {dragonComponent.FoodAmountToCreateEgg}");
            
        }
    }
}