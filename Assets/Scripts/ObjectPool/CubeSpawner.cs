using System;
using UnityEngine;

namespace ObjectPool
{
    public class CubeSpawner : MonoBehaviour
    {
        private ObjectPool _objectPool;

        private void Start()
        {
            _objectPool = ObjectPool.Instance;
        }

        private void FixedUpdate()
        {
            _objectPool.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        }
    }
}