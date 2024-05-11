using System.Collections.Generic;
using FPS;
using FPS.Pool;
using UnityEngine;

namespace Game.Scripts.ECS
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [field: SerializeField] public DragonView DragonView{ get; private set; }
        [field: SerializeField] public SerializableDictionary<DragonType,Material> DragonsSkins { get; private set; }
    }
}