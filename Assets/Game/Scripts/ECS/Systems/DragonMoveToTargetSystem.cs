using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class DragonMoveToTargetSystem : IEcsRunSystem
    {
        private SceneData sceneData;
        private EcsFilter<DragonComponent> dragonFilter;
        public void Run()
        {
            foreach (var i in dragonFilter)
            {
                ref var dragonComponent = ref dragonFilter.Get1(i);


                dragonComponent.dragonNavMeshAgent.SetDestination(sceneData.target.position);
            }
        }
    }
}