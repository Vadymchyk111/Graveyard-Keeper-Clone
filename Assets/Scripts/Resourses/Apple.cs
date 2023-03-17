using System;
using Collectable;
using UnityEngine;

namespace Resourses
{
    public class Apple : MonoBehaviour, ICollectable, IEatable
    {
        public event Action<bool> OnCollected;
        public bool IsCollected { get; set; }
        public void DoCollect()
        {
            SetCollected(true);
        }

        public void UnCollect()
        {
            SetCollected(false);
        }
        
        public void DoEating(Action onEatingCompleted)
        {
            onEatingCompleted?.Invoke();
            Destroy(gameObject);
        }

        private void SetCollected(bool isCollected)
        {
            IsCollected = isCollected;
            OnCollected?.Invoke(isCollected);
        }
    }
}