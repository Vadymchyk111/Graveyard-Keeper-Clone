using System;
using Collectable;
using PlayerInventory;
using PlayerInventory.Item;
using UnityEngine;
using Values.ScriptableObjects;

namespace Resourses
{
    public class Rock : MonoBehaviour, ICollectable
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