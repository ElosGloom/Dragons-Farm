using FPS.Pool;
using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.ECS.Monobehaviours;
using Leopotam.Ecs;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class LoadSystem : IEcsInitSystem

    {
        private SceneData _sceneData;
        private EcsWorld _ecsWorld;
        private StaticData _staticData;

        public SaveData Load()
        {
            string jsonData = PlayerPrefs.GetString("SaveData");
            return JsonConvert.DeserializeObject<SaveData>(GZip.Decompress(jsonData));
        }

        public void Init()
        {
            var saveData = Load();
            if (saveData == null) return;
            foreach (var dragonData in saveData.Dragons)
            {
                var dragonEntity = _ecsWorld.NewEntity();
                ref var readyToBornComponent = ref dragonEntity.Get<ReadyToBornComponent>();
                ref var consumerComponent = ref dragonEntity.Get<FoodConsumerComponent>();
                readyToBornComponent.Position = dragonData.Position;
                readyToBornComponent.Type = dragonData.Type;
                consumerComponent.FoodCollected = dragonData.FoodCollected;
            }

            foreach (var eggData in saveData.Eggs)
            {
                var eggEntity = _ecsWorld.NewEntity();
                ref var eggComponent = ref eggEntity.Get<EggComponent>();
                eggComponent.Position = eggData.Position;
                eggComponent.Type = eggData.Type;
                eggComponent.BornTimeLeft = eggData.Timer;
                
            }

            foreach (var foodData in saveData.Food)
            {
                var foodEntity = _ecsWorld.NewEntity();

                ref var foodComponent = ref foodEntity.Get<FoodComponent>();
                foodEntity.Get<AvailableFoodComponent>();

                var food = FluffyPool.Get<Transform>(foodData.Type.ToString());
                food.position = foodData.Position;

                foodComponent.Transform = food.transform;
                foodComponent.Type = foodData.Type;
            }
        }
    }
}