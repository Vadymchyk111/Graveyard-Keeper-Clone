using System;
using Collectable;
using PlayerInventory.ItemFolder;
using UnityEngine;

namespace Resources
{
    public class BaseItem : MonoBehaviour, ICollectable
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
        
        private void SetCollected(bool isCollected)
        {
            IsCollected = isCollected;
            OnCollected?.Invoke(isCollected);
            Destroy(gameObject);
        }
    }
}