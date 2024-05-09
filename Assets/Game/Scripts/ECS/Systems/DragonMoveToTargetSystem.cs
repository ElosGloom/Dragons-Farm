using Game.Scripts.ECS.Components;
using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class DragonMoveToTargetSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent, DragonTargetComponent>.Exclude<BusyDragonComponent> _dragonFilter;
        
        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);
                ref var dragon = ref _dragonFilter.Get1(i);
                ref var dragonTargetComponent = ref _dragonFilter.Get2(i);
                dragon.DragonNavMeshAgent.SetDestination(dragonTargetComponent.Target.position);
                dragon.Animator.SetTrigger("Run");

                dragonEntity.Get<BusyDragonComponent>();
            }
        }
    }
}