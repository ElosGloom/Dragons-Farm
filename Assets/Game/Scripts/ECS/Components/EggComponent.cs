using Game.Scripts.Common;
using Game.Scripts.ECS.Monobehaviours;
using UnityEngine;

namespace Game.Scripts.ECS.Components
{
    public struct EggComponent
    {
        public float BornTimeLeft;
        public DragonType Type;
        public Vector3 Position;
        public EggView EggView;
    }
}