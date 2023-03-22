using UnityEngine;

namespace Player
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly string _isMoving = "isRunning";
        private int _animationLayerIndexTopBody = 1;

        public void SetMove(bool isMoving)
        {
            _animator.SetBool(_isMoving, isMoving);
        }

        public void SetExtraction(bool isActive, string animationParametr)
        {
            float weight = isActive ? 1 : 0;
            _animator.SetBool(animationParametr, isActive);

            _animator.SetLayerWeight(_animationLayerIndexTopBody, weight);
        }
    }
}