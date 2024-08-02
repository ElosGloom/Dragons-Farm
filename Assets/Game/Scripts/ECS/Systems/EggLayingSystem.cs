using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.ECS.Monobehaviours;
using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class EggLayingSystem : IEcsRunSystem
    {
        private EcsFilter<EggComponent>.Exclude<WaitingToHatchComponent> _eggFilter;
        private EcsWorld _ecsWorld;
        private StaticData _staticData;

        public void Run()
        {
            foreach (var i in _eggFilter)
            {
                ref EcsEntity eggEntity = ref _eggFilter.GetEntity(i);
                ref var eggComponent = ref _eggFilter.Get1(i);
                
                EggView eggView = EggFactory.CreateEgg(_staticData,
                    eggComponent.Type,
                    eggComponent.Position);
                eggComponent.TimeToHatch = eggView.timeToHatch;
                eggComponent.BornTimeLeft = eggComponent.TimeToHatch;
                eggComponent.EggView = eggView;
                eggComponent.FillImage = eggView.fillImage;

                eggEntity.Get<WaitingToHatchComponent>();

            }
        }
    }
}