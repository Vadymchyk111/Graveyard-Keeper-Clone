using System;
using Collectable;
using UnityEngine;

namespace Resourses
{
    public class Rock : MonoBehaviour, ICollectable
    {
        public event Action<bool> OnCollected;
        
        public bool IsCollected { get; set; }
        
        public void DoCollect()
        {
            print("Collected Rock");
            SetCollected(true);
        }

        public void UnCollect()
        {
            SetCollected(false);
        }

        private void SetCollected(bool isCollected)
        {
            IsCollected = isCollected;
            OnCollected?.Invoke(isCollected);
        }
    }
}