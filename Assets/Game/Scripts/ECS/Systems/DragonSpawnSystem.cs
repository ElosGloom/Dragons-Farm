using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

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

            var dragonView = DragonFactory.CreateDragon(_staticData, _sceneData);
            dragonComponent.NavMeshAgent = dragonView.navMeshAgent;
            dragonComponent.Animator = dragonView.animator;
        }
    }
}