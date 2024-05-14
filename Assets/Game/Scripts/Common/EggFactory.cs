using Game.Scripts.ECS.Monobehaviours;
using UnityEngine;

namespace Game.Scripts.Common
{
    public static class EggFactory
    {
        public static EggView CreateEgg(Material material,Vector3 spawnPosition)
        {
            var eggView =  FPS.Pool.FluffyPool.Get<EggView>("Egg");
            eggView.transform.position = spawnPosition;
            eggView.renderer.material = material;
            return eggView;
        }
    }
}