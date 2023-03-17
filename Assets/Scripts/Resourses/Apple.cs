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
            print("Im collected");
            SetCollected(true);
        }

        public void UnCollect()
        {
            SetCollected(false);
        }

        public void DoEating()
        {
            print("Im eated");
            Destroy(gameObject);
        }
        
        private void SetCollected(bool isCollected)
        {
            IsCollected = isCollected;
            OnCollected?.Invoke(isCollected);
        }
    }
}