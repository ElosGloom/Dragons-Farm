using Game.Scripts.ECS.Components;
using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class FoodDetectSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent>.Exclude<BusyDragonComponent, DragonTargetComponent> _dragonFilter;
        private EcsFilter<AvailableFoodComponent, FoodComponent> _availableFoodFilter;

        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                foreach (var j in _availableFoodFilter)
                {
                    ref EcsEntity foodEntity = ref _availableFoodFilter.GetEntity(j);
                    ref var foodComponent = ref _availableFoodFilter.Get2(j);

                    ref EcsEntity dragonEntity = ref _dragonFilter.GetEntity(i);
                    ref var dragonComponent = ref dragonEntity.Get<DragonComponent>();
                    if (foodComponent.Type == dragonComponent.SuitableFood)
                    {
                        ref var dragonTargetComponent = ref dragonEntity.Get<DragonTargetComponent>();
                        dragonTargetComponent.Target = foodComponent.Transform;
                        foodEntity.Get<FoodComponent>();
                        foodEntity.Del<AvailableFoodComponent>();
                        break;
                    }
                }
            }
        }
    }
}