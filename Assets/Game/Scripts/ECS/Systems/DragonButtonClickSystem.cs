using System;
using Game.Scripts.Common;
using Game.Scripts.ECS.Components;
using Game.Scripts.UI;
using Game.Scripts.Utils;
using Leopotam.Ecs;

namespace Game.Scripts.ECS.Systems
{
    public class DragonButtonClickSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private SceneData _sceneData;
        private EcsWorld _ecsWorld;
        private DragonType _type;


        public void Init()
        {
            DragonButtonGroupElement.DragonSpawnButtonClick += (SetDragonType);
        }

        public void Destroy()
        {
            DragonButtonGroupElement.DragonSpawnButtonClick -= (SetDragonType);
        }

        private void SetDragonType(DragonType type)
        {
            _type = type;
            var dragonEntity = _ecsWorld.NewEntity();
            ref var readyToBornComponent = ref dragonEntity.Get<ReadyToBornComponent>();
            readyToBornComponent.Position = RandomPosition.GetRandomSpawnPosition(_sceneData);
            readyToBornComponent.Type = _type;
        }
    }
}