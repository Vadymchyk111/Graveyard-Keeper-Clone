using System;
using System.Collections.Generic;
using Collectable;
using UnityEngine;

namespace PlayerInventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action OnInventoryChanged; 

        private List<ICollectable> _collectables = new();

        public static Inventory instance;
        
        public List<ICollectable> Collectables => _collectables;

        private void Awake()
        {
            instance = this;
        }

        public void AddItem(ICollectable collectable)
        {
            _collectables.Add(collectable);
            print(_collectables.Count);
            OnInventoryChanged?.Invoke();
        }
        
        public void RemoveItem(ICollectable collectable)
        {
            _collectables.Remove(collectable);
        }
    }
}