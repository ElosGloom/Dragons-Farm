using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class DragonMoveSystem : IEcsRunSystem
    {
        private EcsFilter<DragonComponent> dragonFilter;
        public void Run()
        {
            foreach (var i in dragonFilter)
            {
                ref var dragonComponent = ref dragonFilter.Get1(i);
               

                dragonComponent.dragonRigidbody.AddForce(1,1,1);
            }
        }
    }
}