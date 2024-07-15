using Game.Scripts.Common;
using Game.Scripts.UI;
using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class FoodTypeSetterSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;
        private FoodType _type;

        public void Init()
        {
            FoodButtonElement.FoodSpawnButtonClick += SetFruitType;
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            FoodButtonElement.FoodSpawnButtonClick -= SetFruitType;
        }

        private void SetFruitType(FoodType foodType)
        {
            _type = foodType;
        }
    }
}