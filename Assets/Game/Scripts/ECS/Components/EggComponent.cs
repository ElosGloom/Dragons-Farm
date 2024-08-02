using Game.Scripts.Common;
using Game.Scripts.ECS.Monobehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.ECS.Components
{
    public struct EggComponent
    {
        public float BornTimeLeft;
        public float TimeToHatch;
        public DragonType Type;
        public Vector3 Position;
        public EggView EggView;
        public Image FillImage;
    }
}