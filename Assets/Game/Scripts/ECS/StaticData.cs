using FPS.Pool;
using UnityEngine;

namespace Game.Scripts.ECS
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [field: SerializeField] public GameObject DragonPrefab { get; private set; }
        [field: SerializeField] public float DragonMovementSpeed { get; private set; }
    }
}