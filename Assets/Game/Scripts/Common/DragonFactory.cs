using Game.Scripts.ECS;
using UnityEngine;

namespace Game.Scripts
{
    public static class DragonFactory
    {
        public static DragonView CreateDragon(StaticData staticData, SceneData sceneData)
        {
            var dragonType = Utils.Enum.GetRandom<DragonType>();
            staticData.DragonsSkins.TryGetValue(dragonType, out var material);
            var dragonRenderers = staticData.DragonView.GetComponent<DragonView>();
            foreach (var i in dragonRenderers.renderers)
            {
                i.material = material;
            }

            DragonView dragon = Object.Instantiate(staticData.DragonView,
                GetRandomSpawnPosition(sceneData),
                GetRandomRotation());
            
            return dragon;
        }

        private static Vector3 GetRandomSpawnPosition(SceneData sceneData)
        {
            float rangeX = sceneData.SpawnRange.x;
            float rangeZ = sceneData.SpawnRange.z;

            var centerPosition = sceneData.Spawner.position;

            float randomX = Random.Range(centerPosition.x - rangeX, centerPosition.x + rangeX);
            float randomZ = Random.Range(centerPosition.z - rangeZ, centerPosition.z + rangeZ);
            var randomPosition = new Vector3(randomX, sceneData.SpawnRange.y, randomZ);

            return randomPosition;
        }

        private static Quaternion GetRandomRotation()
        {
            float randomRotationY = Random.Range(0, 360);

            var randomRotation = Quaternion.Euler(0, randomRotationY, 0);
            return randomRotation;
        }
    }
}