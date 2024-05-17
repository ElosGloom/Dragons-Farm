using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.ECS.Components
{
    public struct ReadyToBornComponent
    {
        public DragonType Type;
        public Vector3 Position;
    }
}