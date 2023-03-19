using System;
using Collectable;
using PlayerInventory;
using UnityEngine;

namespace Resourses
{
    public class Rock : MonoBehaviour, ICollectable
    {
        [SerializeField] private Item _item;
        
        public event Action<bool> OnCollected;
        public bool IsCollected { get; set; }
        public Item Item
        {
            get => _item;
            set => _item = value;
        }

        public void DoCollect()
        {
            SetCollected(true);
            Destroy(gameObject);
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