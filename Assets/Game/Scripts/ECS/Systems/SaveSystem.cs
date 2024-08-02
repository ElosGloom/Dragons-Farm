using System.Collections.Generic;
using FPS.Pool;
using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Utils;
using Leopotam.Ecs;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class SaveSystem : IEcsDestroySystem
    {
        private StaticData _staticData;
        private EcsFilter<EggComponent> _eggFilter;
        private EcsFilter<FoodComponent> _foodFilter;
        private EcsFilter<DragonComponent, FoodConsumerComponent, MovableComponent> _dragonFilter;

        public void Save(SaveData data)
        {
            string jsonData = JsonConvert.SerializeObject(data, new Vector3Converter());
            PlayerPrefs.SetString("SaveData", GZip.Compress(jsonData));
        }

        public void Destroy()
        {
            var saveData = new SaveData();
            saveData.Dragons = new List<DragonDTO>();
            saveData.Food = new List<FoodDTO>();
            saveData.Eggs = new List<EggDTO>();

            foreach (var i in _dragonFilter)
            {
                ref var dragonComponent = ref _dragonFilter.Get1(i);
                ref var consumerComponent = ref _dragonFilter.Get2(i);
                ref var movableComponent = ref _dragonFilter.Get3(i);

                var transform = movableComponent.Transform;


                var dragonData = new DragonDTO
                {
                    FoodCollected = consumerComponent.FoodCollected,
                    Position = transform.position,
                    Type = dragonComponent.Type
                };
                saveData.Dragons.Add(dragonData);
            }

            foreach (var i in _eggFilter)
            {
                ref var eggComponent = ref _eggFilter.Get1(i);


                var position = eggComponent.Position;


                var eggData = new EggDTO
                {
                    Timer = eggComponent.BornTimeLeft,
                    Position = position,
                    Type = eggComponent.Type
                };
                saveData.Eggs.Add(eggData);
            }

            foreach (var i in _foodFilter)
            {
                ref var foodComponent = ref _foodFilter.Get1(i);
                var foodData = new FoodDTO
                {
                    Position = foodComponent.Transform.position,
                    Type = foodComponent.Type
                };
                saveData.Food.Add(foodData);
            }

            Save(saveData);
        }
    }
}