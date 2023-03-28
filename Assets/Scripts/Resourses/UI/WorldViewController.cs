using Player;
using UnityEngine;

namespace Resourses.UI
{
    public class WorldViewController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private MoveByPhysicsController _playerMovement;

        private void OnEnable()
        {
            _playerMovement.OnPlayerMove += LookToCamera;
        }

        private void OnDisable()
        {
            _playerMovement.OnPlayerMove -= LookToCamera;
        }

        private void LookToCamera(bool isMoving)
        {
            if (!isMoving)
            {
                return;
            }
            
            Vector3 cameraDirection = _camera.transform.position - transform.position;
            Vector3 localDirection = transform.InverseTransformDirection(cameraDirection);
            localDirection.y = 0f;
            transform.LookAt(transform.position - transform.TransformDirection(localDirection), Vector3.up);
        }
    }
}