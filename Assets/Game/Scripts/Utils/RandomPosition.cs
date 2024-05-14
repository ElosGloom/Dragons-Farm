using Game.Scripts.ECS;
using UnityEngine;

namespace Game.Scripts.Utils
{
    public static class RandomPosition
    {
        public static Vector3 GetRandomSpawnPosition(SceneData sceneData)
        {
            float rangeX = sceneData.SpawnRange.x;
            float rangeZ = sceneData.SpawnRange.z;

            var centerPosition = sceneData.Spawner.position;

            float randomX = Random.Range(centerPosition.x - rangeX, centerPosition.x + rangeX);
            float randomZ = Random.Range(centerPosition.z - rangeZ, centerPosition.z + rangeZ);
            var randomPosition = new Vector3(randomX, sceneData.SpawnRange.y, randomZ);

            return randomPosition;
        }
    }
}