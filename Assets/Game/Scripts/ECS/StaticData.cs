using UnityEngine;

namespace Game.Scripts.ECS
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
       public GameObject dragonPrefab;
       [SerializeField] private float dragonMovementSpeed;
    }
}