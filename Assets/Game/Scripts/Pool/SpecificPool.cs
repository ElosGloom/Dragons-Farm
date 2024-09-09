using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Pool
{
    public class SpecificPool:MonoBehaviour
    {
       [SerializeField] private GameObject _prefab;
        public int StartPoolSize;
        public  List<GameObject> _objects = new();
        private  Transform _transform;
        
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
            _transform = transform;
            for (int i = 0; i < StartPoolSize; i++)
            {
                SpawnObject();
            }
        }
        
        

    }
}