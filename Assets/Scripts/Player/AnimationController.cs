using UnityEngine;

namespace Player
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private MoveByPhysicsController _moveByPhysicsController;
        [SerializeField] private PlayerExtractor _playerExtractor;
        [SerializeField] private Animator _animator;

        private readonly string _isMoving = "isRunning";
        private readonly string _chopping = "Chopping";

        private void OnEnable()
        {
            _moveByPhysicsController.OnPlayerMove += SetMove;
            _playerExtractor.OnExtracting += SetChoppingTree;
        }

        private void OnDisable()
        {
            _moveByPhysicsController.OnPlayerMove -= SetMove;
            _playerExtractor.OnExtracting += SetChoppingTree;
        }
        
        private void SetMove(bool isMoving)
        {
            _animator.SetBool(_isMoving, isMoving);
        }

        private void SetChoppingTree()
        {
            _animator.SetTrigger(_chopping);
        }

        //TODO add SetCut + switch animation layer
        //TODO add SetDig + switch animation layer
        //TODO add SetHollow + switch animation layer
    }
}