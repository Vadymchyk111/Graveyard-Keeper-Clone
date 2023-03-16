using Player;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private MoveByPhysicsController _moveByPhysicsController;

    private const string IS_MOVING = "isRunning";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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
        _animator.SetBool(IS_MOVING, isMoving);
    }
}
