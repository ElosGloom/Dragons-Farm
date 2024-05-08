using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.ECS.Systems
{
    public class DragonSpawnSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EcsEntity dragonEntity = _ecsWorld.NewEntity();

                ref var dragon = ref dragonEntity.Get<DragonComponent>();

                float rangeX = _sceneData.SpawnRange.x;
                float rangeZ = _sceneData.SpawnRange.z;

                Vector3 centerPosition = _sceneData.Spawner.position;

                float randomX = Random.Range(centerPosition.x - rangeX, centerPosition.x + rangeX);
                float randomZ = Random.Range(centerPosition.z - rangeZ, centerPosition.z + rangeZ);
                Vector3 randomPosition = new Vector3(randomX, _sceneData.SpawnRange.y, randomZ);
                //
                // float randomRotationX = Random.Range(0, 360);
                // float randomZ = Random.Range(0, 360);

                // Quaternion randomRotation = Quaternion.Euler(randomRotationX, 0, randomZ);


                var dragonGO = Object.Instantiate(_staticData.DragonPrefab, randomPosition,
                    Quaternion.identity);
                dragon.DragonNavMeshAgent = dragonGO.GetComponent<NavMeshAgent>();
            }
        }
    }
}