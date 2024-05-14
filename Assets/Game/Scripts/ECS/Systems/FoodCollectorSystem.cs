using FPS.Pool;
using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class FoodCollectorSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent, FoodConsumerComponent,DragonTargetComponent, ReadyToEatComponent> _dragonFilter;
        private StaticData _staticData;

        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);

                ref var dragonTargetComponent = ref _dragonFilter.Get3(i);
                ref var foodConsumerComponent = ref _dragonFilter.Get2(i);

                ref var dragonComponent = ref _dragonFilter.Get1(i);
                dragonComponent.EatingTimeLeft -= Time.deltaTime;

                if (dragonComponent.EatingTimeLeft <= 0)
                {
                    foodConsumerComponent.FoodCollected++;
                    FluffyPool.Return(dragonTargetComponent.Target);
                    dragonTargetComponent.Target = null;
                    dragonEntity.Del<DragonTargetComponent>();
                    dragonEntity.Del<BusyDragonComponent>();
                    dragonEntity.Del<ReadyToEatComponent>();
                    dragonComponent.Animator.SetTrigger(AnimationValues.Idle);
                }
            }
        }
    }
}