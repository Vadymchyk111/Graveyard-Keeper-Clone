using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        [Serializable]
        public class Pool
        {
            public string poolTag;
            public GameObject prefab;
            public int size;
        }

        public static ObjectPool Instance;

        private void Awake()
        {
            Instance = this;
        }

        public List<Pool> poolList;
        private Dictionary<string, Queue<GameObject>> poolDictionary;

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in poolList)
            {
                Queue<GameObject> objectPool = new();

                for (var i = 0; i < pool.size; i++)
                {
                    var obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                
                poolDictionary.Add(pool.poolTag, objectPool);
            }
        }

        public void SpawnFromPool(string poolTag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(poolTag))
            {
                return;
            }
            
            var objectToSpawn = poolDictionary[poolTag].Dequeue();
            
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            
            IObjectPoolable objectPoolable = objectToSpawn.GetComponent<IObjectPoolable>();

            objectPoolable?.OnObjectSpawn();

            poolDictionary[poolTag].Enqueue(objectToSpawn);
        }
    }
}