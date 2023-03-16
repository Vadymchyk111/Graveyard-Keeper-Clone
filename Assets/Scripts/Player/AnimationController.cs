using Player;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private MoveByPhysicsController _moveByPhysicsController;
    [SerializeField] private Animator _animator;

    private string _isMoving = "isRunning";

    private void OnEnable()
    {
        _moveByPhysicsController.OnPlayerMove += SetAnimation;
    }

    private void OnDisable()
    {
        _moveByPhysicsController.OnPlayerMove -= SetAnimation;
    }

    private void SetAnimation(bool isMoving)
    {
        _animator.SetBool(_isMoving, isMoving);
    }
}