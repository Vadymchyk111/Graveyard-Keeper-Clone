using System;
using Collectable;
using UnityEngine;

namespace Resourses
{
    public class Mushroom : MonoBehaviour, ICollectable, IEatable
    {
        public event Action<bool> OnCollected;
        
        public bool IsCollected { get; set; }
        
        public void DoCollect()
        {
            print("I collect mushroom");
            SetCollected(true);
        }

        public void UnCollect()
        {
            SetCollected(false);
        }

        public void DoEating()
        {
            print("Mushroom is eaten");
            Destroy(gameObject);
        }
        
        private void SetCollected(bool isCollected)
        {
            IsCollected = isCollected;
            OnCollected?.Invoke(isCollected);
        }
    }
}