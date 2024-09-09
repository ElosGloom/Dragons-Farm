using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Pool
{
    public class SpecificPool : MonoBehaviour
    {
        public List<GameObject> _objects = new();
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int StartPoolSize;
        private Transform _transform;

        public void AddObject(GameObject go)
        {
            _objects.Add(go);
        }

        public GameObject SpawnObject()
        {
            GameObject newObject = Instantiate(_prefab, transform.position, Quaternion.identity, _transform);
            AddObject(newObject);
            return newObject;
        }

        private void Start()
        {
            GameObject parent = new GameObject(_prefab.name);
            parent.transform.parent = transform;
            _transform = parent.transform;
            for (int i = 0; i < StartPoolSize; i++)
            {
                SpawnObject();
            }
        }
    }
}