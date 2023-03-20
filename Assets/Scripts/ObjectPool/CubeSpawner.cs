using UnityEngine;

namespace ObjectPool
{
    public class CubeSpawner : MonoBehaviour
    {
        private ObjectPool _objectPool;
        private string _objectTag = "Cube";

        private void Start()
        {
            _objectPool = ObjectPool.Instance;
        }

        private void FixedUpdate()
        {
            _objectPool.SpawnFromPool(_objectTag, transform.position, Quaternion.identity);
        }
    }
}