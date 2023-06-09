using System;
using UnityEngine;

namespace Player
{
    public class AnimationController : MonoBehaviour
    {
        public event Action OnMiningHit;
        
        [SerializeField] private Animator _animator;

        private readonly string _isMoving = "isRunning";
        private readonly int _animationLayerIndexTopBody = 1;

        public void SetMove(bool isMoving)
        {
            _animator.SetBool(_isMoving, isMoving);
        }

        public void SetExtraction(bool isActive, string animationParameter)
        {
            float weight = isActive ? 1 : 0;
            _animator.SetBool(animationParameter, isActive);

            _animator.SetLayerWeight(_animationLayerIndexTopBody, weight);
        }

        public void DoMiningHit()
        {
            OnMiningHit?.Invoke();
        }
    }
}