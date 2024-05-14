using FPS;
using Game.Scripts.Common;
using Game.Scripts.ECS.Monobehaviours;
using UnityEngine;

namespace Game.Scripts.ECS
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [field: SerializeField] public DragonView DragonView{ get; private set; }
        [field: SerializeField] public SerializableDictionary<DragonType,DragonStats> DragonsStats { get; private set; }
    }
}