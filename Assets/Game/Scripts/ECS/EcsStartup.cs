using Game.Scripts.ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private StaticData configuration;
        [SerializeField] private SceneData sceneData;


        private EcsWorld _ecsWorld;
        private EcsSystems _systems;

        private void Start()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);

            RuntimeData runtimeData = new RuntimeData();

            _systems
                .Add(new DragonButtonClickSystem())
                .Add(new DragonSpawnSystem())
                .Add(new SatietyCheckSystem())
                .Add(new EggCreatorSystem())
                .Add(new EggHatchingSystem())
                .Add(new FoodSpawnSystem())
                .Add(new FoodDetectSystem())
                .Add(new  RotateToTargetSystem())
                .Add(new DragonMoveToTargetSystem())
                .Add(new TargetDistanceMeterSystem())
                .Add(new FoodCollectorSystem())
                .Inject(configuration)
                .Inject(sceneData)
                .Inject(runtimeData)
                .Init();
        }


        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            _systems?.Destroy();
            _systems = null;
            _ecsWorld?.Destroy();
            _ecsWorld = null;
        }
    }
}