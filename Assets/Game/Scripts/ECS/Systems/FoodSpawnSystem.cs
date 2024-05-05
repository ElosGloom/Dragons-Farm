using FPS.Pool;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class FoodSpawnSystem: IEcsRunSystem
    {
        private EcsWorld ecsWorld;
        private StaticData staticData;
        private SceneData sceneData;

        
        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    var hitPoint = hit.point;
                    var food = FluffyPool.Get<Transform>("Grass");
                    food.position = hitPoint;
                }
            } 
        }
    }
}