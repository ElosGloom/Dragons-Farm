using UnityEngine;

namespace Game.Scripts.ECS
{
    public class AppInitializer : MonoBehaviour
    {
        [SerializeField] private EcsStartup startup;
        
        private async void Awake()
        {
            await FPS.Pool.FluffyPool.InitAsync();
            startup.gameObject.SetActive(true);
        }
    }
}