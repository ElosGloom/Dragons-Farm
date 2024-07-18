using Game.Scripts.ECS;
using UnityEngine;

namespace Game.Scripts.Common
{
    public struct EggDTO
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public DragonType Type;
        public StaticData StaticData;
        public float Timer;
    }
}