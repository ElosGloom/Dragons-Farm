using Game.Scripts.ECS.Components;
using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class SatietyCheckSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent, FoodConsumerComponent> _dragonFilter;
        
        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);
                ref var foodConsumerComponent = ref _dragonFilter.Get2(i);


                if (foodConsumerComponent.FoodCollected == foodConsumerComponent.FoodAmountToCreateEgg)
                {
                    dragonEntity.Get<SatietyComponent>();
                }
            }
        }
    }
}