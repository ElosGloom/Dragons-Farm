using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class DragonSpawnSystem : IEcsRunSystem
    {
        private EcsWorld ecsWorld;
        private StaticData staticData;
        private SceneData sceneData;

        public void Run()
        {
            EcsEntity dragonEntity = ecsWorld.NewEntity();

            ref var dragon = ref dragonEntity.Get<DragonComponent>();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float rangeX = sceneData.spawnRangeX;
                float rangeZ = sceneData.spawnRangeZ;

                Vector3 centerPosition = sceneData.spawner.position;

                float randomX = Random.Range(centerPosition.x - rangeX, centerPosition.x + rangeX);
                float randomZ = Random.Range(centerPosition.z - rangeZ, centerPosition.z + rangeZ);
                Vector3 randomPosition = new Vector3(randomX, sceneData.spawnHeight,randomZ);
                //
                // float randomRotationX = Random.Range(0, 360);
                // float randomZ = Random.Range(0, 360);

                // Quaternion randomRotation = Quaternion.Euler(randomRotationX, 0, randomZ);


                GameObject dragonGO = Object.Instantiate(staticData.dragonPrefab, randomPosition,
                    Quaternion.identity);
                dragon.dragonRigidbody = dragonGO.GetComponent<Rigidbody>();
            }
        }
    }
}