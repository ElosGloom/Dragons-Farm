using Game.Scripts.ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private StaticData configuration;
        [SerializeField] private SceneData sceneData;


        private EcsWorld ecsWorld;
        private EcsSystems systems;

        private void Start()
        {
            ecsWorld = new EcsWorld();
            systems = new EcsSystems(ecsWorld);

            RuntimeData runtimeData = new RuntimeData();

            systems
                .Add(new DragonSpawnSystem())
                .Add(new FoodSpawnSystem())
                .Add(new DragonMoveToTargetSystem())
                .Inject(configuration)
                .Inject(sceneData)
                .Inject(runtimeData)
                .Init();
        }


        private void Update()
        {
            systems?.Run();
        }

        private void OnDestroy()
        {
            systems?.Destroy();
            systems = null;
            ecsWorld?.Destroy();
            ecsWorld = null;
        }
    }
}