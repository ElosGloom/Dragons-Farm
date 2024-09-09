using System;
using FPS;
using UnityEngine;

namespace Game.Scripts.Pool
{
    [Serializable]
    public class PoolObjects : MonoBehaviour
    {
        public static PoolObjects Instance { get; private set; }
        [SerializeField] private SerializableDictionary<string, SpecificPool> pools = new();

        private void Awake()
        {
            Instance = this;
        }

        private void ResetObject(GameObject go)
        {
            var rigidBody = go.GetComponent<Rigidbody>();
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            go.transform.rotation = Quaternion.identity;
        }

        public static void ReturnToPool(GameObject go)
        {
            go.SetActive(false);
        }


        public static GameObject GetFromPool(string key)
        {
            Instance.pools.TryGetValue(key, out var specificPool);
            foreach (var i in specificPool!._objects)
            {
                if (i.gameObject.activeInHierarchy == false)
                {
                    i.SetActive(true);
                    Instance.ResetObject(i);
                    return i;
                }
            }

            return specificPool.SpawnObject();
        }
    }
}