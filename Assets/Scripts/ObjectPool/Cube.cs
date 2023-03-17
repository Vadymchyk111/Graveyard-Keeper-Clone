using UnityEngine;

namespace ObjectPool
{
    public class Cube : MonoBehaviour, IObjectPoolable
    {
        public float upForce = 1f;
        public float sideForce = .1f;
        
        public void OnObjectSpawn()
        {
            var xForce = Random.Range(-sideForce, sideForce);
            var yForce = Random.Range(upForce / 2f, upForce);
            var zForce = Random.Range(-sideForce, sideForce);

            Vector3 force = new Vector3(xForce, yForce, zForce);

            GetComponent<Rigidbody>().velocity = force;
        }
    }
}