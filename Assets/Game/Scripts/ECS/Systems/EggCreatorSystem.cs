using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.ECS.Monobehaviours;
using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class EggCreatorSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent, SatietyComponent, FoodConsumerComponent> _dragonFilter;
        private EcsWorld _ecsWorld;

        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);
                ref var dragonComponent = ref _dragonFilter.Get1(i);
                ref var foodConsumerComponent = ref _dragonFilter.Get3(i);
                
                foodConsumerComponent.FoodCollected = 0;
                
                var eggEntity = _ecsWorld.NewEntity();
                ref var eggComponent = ref eggEntity.Get<EggComponent>();
                eggComponent.Type = dragonComponent.Type;

                EggView eggView = EggFactory.CreateEgg(dragonComponent.EggMaterial,
                    dragonComponent.NavMeshAgent.transform.position);
                eggComponent.Position = eggView.transform.position;
                eggComponent.BornTimeLeft = eggView.timeToHatch;
                eggComponent.EggView = eggView;
                
                dragonEntity.Del<SatietyComponent>();
                
            }
        }
    }
}