using FPS.Pool;
using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class EggHatchingSystem : IEcsRunSystem
    {
        private EcsFilter<EggComponent> _eggFilter;
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var i in _eggFilter)
            {
                ref EcsEntity eggEntity = ref _eggFilter.GetEntity(i);
                ref var eggComponent = ref _eggFilter.Get1(i);
                eggComponent.BornTimeLeft -= Time.deltaTime;

                if (eggComponent.BornTimeLeft <= 0)
                {
                    var dragonEntity = _ecsWorld.NewEntity();
                    ref var readyToBornComponent = ref dragonEntity.Get<ReadyToBornComponent>();
                    readyToBornComponent.Position = eggComponent.Position;
                    readyToBornComponent.Type = eggComponent.Type;

                    FluffyPool.Return(eggComponent.EggView);
                    eggEntity.Destroy();
                }
            }
        }
    }
}