using Player;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private MoveByPhysicsController _moveByPhysicsController;
    [SerializeField] private Animator _animator;

    private readonly string _isMoving = "isRunning";

    private void OnEnable()
    {
        _moveByPhysicsController.OnPlayerMove += SetAnimation;
    }

    private void OnDisable()
    {
        _moveByPhysicsController.OnPlayerMove -= SetAnimation;
    }

    //TODO rename to SetMove
    private void SetAnimation(bool isMoving)
    {
        _animator.SetBool(_isMoving, isMoving);
    }

    //TODO add SetCut + switch animation layer
    //TODO add SetDig + switch animation layer
    //TODO add SetHollow + switch animation layer
}