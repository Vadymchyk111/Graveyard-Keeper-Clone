using Collectable;
using PlayerInventory;
using PlayerInventory.Item;
using UnityEngine;

namespace Player
{
    public class PlayerCollector : MonoBehaviour, ICollector
    {
        private Inventory _inventory;

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void PickUp(ICollectable collectable)
        {
            if (_inventory.InventorySize >= 16)
            {
                return;
            }
            
            collectable.DoCollect();
            _inventory.AddItem(collectable.Item);
        }
        
        public void PickUp(Item item)
        {
            if (_inventory.InventorySize >= 16)
            {
                return;
            }
            
            _inventory.AddItem(item);
        }

        public void ThrowOut(ICollectable collectable)
        {
            if (_inventory.InventorySize <= 0)
            {
                return;
            }
            
            collectable.UnCollect();
            _inventory.RemoveItem(collectable.Item);
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