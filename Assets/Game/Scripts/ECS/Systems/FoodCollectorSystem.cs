using FPS.Pool;
using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class FoodCollectorSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent, DragonTargetComponent, ReadyToEatComponent> _dragonFilter;
        private StaticData _staticData;

        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);

                ref var dragonTargetComponent = ref _dragonFilter.Get2(i);

                ref var dragon = ref _dragonFilter.Get1(i);
                dragon.EatingTimeLeft -= Time.deltaTime;

                if (dragon.EatingTimeLeft <= 0)
                {
                    FluffyPool.Return(dragonTargetComponent.Target);
                    dragonTargetComponent.Target = null;
                    dragonEntity.Del<DragonTargetComponent>();
                    dragonEntity.Del<BusyDragonComponent>();
                    dragonEntity.Del<ReadyToEatComponent>();
                    dragon.Animator.SetTrigger("Idle");
                }
            }
        }
    }
}