using System;
using System.Collections.Generic;
using Collectable;
using UnityEngine;

namespace PlayerInventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action OnInventoryChanged; 

        private readonly List<ICollectable> _collectables = new();

        public static Inventory instance;
        
        public List<ICollectable> Collectables => _collectables;
        public int InventorySize => _collectables.Count;

        private void Awake()
        {
            instance = this;
        }

        public void AddItem(ICollectable collectable)
        {
            _collectables.Add(collectable);
            OnInventoryChanged?.Invoke();
        }
        
        public void RemoveItem(ICollectable collectable)
        {
            _collectables.Remove(collectable);
        }
    }
}