using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class DragonMoveToTargetSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent, DragonTargetComponent,MovableComponent>.Exclude<BusyDragonComponent> _dragonFilter;

        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);
                ref var dragonTargetComponent = ref _dragonFilter.Get2(i);
                ref var movableComponent = ref _dragonFilter.Get3(i);
                
                movableComponent.NavMeshAgent.SetDestination(dragonTargetComponent.Target.position);
                movableComponent.Animator.SetTrigger(AnimationValues.Run);

                dragonEntity.Get<BusyDragonComponent>();
            }
        }
    }
}