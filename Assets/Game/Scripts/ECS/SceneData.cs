using UnityEngine;

namespace Game.Scripts.ECS
{
    public class SceneData : MonoBehaviour
    {
        [field: SerializeField] public Vector3 SpawnRange { get; private set; }
        [field: SerializeField] public Transform Spawner { get; private set; }
        [field: SerializeField] public Camera Camera { get; private set; }
        
    }
}