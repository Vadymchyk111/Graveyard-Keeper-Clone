using System;
using System.Collections.Generic;
using Collectable;
using PlayerInventory;
using UnityEngine;

namespace Player
{
    public class PlayerCollector : MonoBehaviour, ICollector
    {
        private Inventory _inventory;
        
        private void Start()
        {
            _inventory = Inventory.instance;
        }

        public void PickUp(ICollectable collectable)
        {
            if (_inventory.InventorySize >= 16)
            {
                return;
            }
            
            collectable.DoCollect();
            _inventory.AddItem(collectable);
        }

        public void ThrowOut(ICollectable collectable)
        {
            if (_inventory.InventorySize <= 0)
            {
                return;
            }
            
            collectable.UnCollect();
            _inventory.RemoveItem(collectable);
        }

        private void OnTriggerEnter(Collider other)
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();

            if (collectable is null)
            {
                return; 
            }

            PickUp(collectable);
        }
    }
}