using Game.Scripts.ECS;
using Game.Scripts.ECS.Monobehaviours;
using UnityEngine;

namespace Game.Scripts.Common
{
    public static class EggFactory
    {
        public static EggView CreateEgg(StaticData staticData, DragonType dragonType, Vector3 spawnPosition)
        {
            var eggView = FPS.Pool.FluffyPool.Get<EggView>("Egg");
            staticData.DragonsStats.TryGetValue(dragonType, out var stats);
            eggView.transform.position = spawnPosition;
            eggView.eggRenderer.material = stats.eggMaterial;
            return eggView;
        }
    }
}