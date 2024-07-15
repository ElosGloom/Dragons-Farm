using FPS.Pool;
using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.UI;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Game.Scripts.ECS.Systems
{
    public class FoodSpawnSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;
        private FoodType _type;
        private bool _hasType = false;

        public void Init()
        {
            FoodButtonElement.FoodSpawnButtonClick += SetFruitType;
        }

        public void Run()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            if (_hasType == false) return;

            if (EventSystem.current.IsPointerOverGameObject()) return;

            var ray = _sceneData.Camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit)) return;
            
            var hitPoint = hit.point;
            
            if (hit.collider.gameObject.GetComponent<NavMeshAgent>()) return;
            
            var foodEntity = _ecsWorld.NewEntity();

            ref var foodComponent = ref foodEntity.Get<FoodComponent>();
            foodEntity.Get<AvailableFoodComponent>();

            var food = FluffyPool.Get<Transform>(_type.ToString());
            food.position = hitPoint;

            foodComponent.Transform = food.transform;
            foodComponent.Type = _type;
        }

        public void Destroy()
        {
            FoodButtonElement.FoodSpawnButtonClick -= SetFruitType;
        }

        private void SetFruitType(FoodType foodType)
        {
            _type = foodType;
            _hasType = true;
        }
    }
}