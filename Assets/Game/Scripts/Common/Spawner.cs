using Game.Scripts.Pool;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game.Scripts.Common
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Collider spawnTrigger;
        [SerializeField] private Button cubeButton;
        [SerializeField] private Button sphereButton;
        private GameObject _cube;
        private GameObject _sphere;

        private void Start()
        {
            cubeButton.onClick.AddListener(OnCubeButtonClick);
            sphereButton.onClick.AddListener(OnSphereButtonClick);
        }

        private void OnCubeButtonClick()
        {
            _cube = PoolObjects.GetFromPool("cube");
            _cube.transform.position = GetRandomSpawnPosition();
        }

        private void OnSphereButtonClick()
        {
            _sphere = PoolObjects.GetFromPool("sphere");
            _sphere.transform.position = GetRandomSpawnPosition();
        }

        private Vector3 GetRandomSpawnPosition()
        {
            var centerPosition = spawnTrigger.transform.position;

            float randomX = Random.Range(centerPosition.x - 5, centerPosition.x + 5);
            float randomZ = Random.Range(centerPosition.z - 5, centerPosition.z + 5);
            var randomPosition = new Vector3(randomX, 7, randomZ);

            return randomPosition;
        }
    }
}