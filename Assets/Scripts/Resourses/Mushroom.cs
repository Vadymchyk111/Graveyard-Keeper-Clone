using System;
using Collectable;
using Eatable;
using PlayerInventory;
using PlayerInventory.Item;
using UnityEngine;

namespace Resourses
{
    public class Mushroom : MonoBehaviour, ICollectable, IEatable
    {
        public event Action<bool> OnCollected;
        
        [SerializeField] private Item _item;
        
        public bool IsCollected { get; set; }
        public Item Item
        {
            get => _item;
            set => _item = value;
        }

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