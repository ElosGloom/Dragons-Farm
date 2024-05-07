using FPS.Pool;
using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class FoodCollectorSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent, DragonTargetComponent> _dragonFilter;

        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);

                ref var dragonTargetComponent = ref _dragonFilter.Get2(i);

                var dragonGO = dragonEntity.Get<DragonComponent>().DragonNavMeshAgent.GameObject();

                var dragonPosition = dragonGO.GetComponent<Transform>().position;
                var targetPosition = dragonTargetComponent.Target.position;

                Vector2 dragonPos2D = new Vector2(dragonPosition.x, dragonPosition.z);
                Vector2 targetPos2D = new Vector2(targetPosition.x, targetPosition.z);

                float distanceToTarget = Vector2.Distance(dragonPos2D, targetPos2D);


                if (distanceToTarget <= 0f)
                {
                    FluffyPool.Return(dragonTargetComponent.Target);
                    dragonTargetComponent.Target = null;
                    dragonEntity.Del<DragonTargetComponent>();
                    dragonEntity.Del<BusyDragonComponent>();
                }
            }
        }
    }
}