using System;
using System.Collections.Generic;
using System.Linq;
using ItemReceiver;
using PlayerInventory;
using PlayerInventory.Item;
using Resourses.Generall;
using UnityEngine;

namespace ReceiverObjects
{
    public class ReceiverBase : MonoBehaviour, IItemReceiver
    {
        public event Action<bool> OnReceived;

        [SerializeField] private ResourceHolderData _resourceHolder;

        public ResourceHolderData ResourceHolderData => _resourceHolder;
        
        public bool ReceiveItems(Inventory inventory)
        {
            if (inventory.Items == null || inventory.Items.Count == 0)
            {
                return false;
            }

            List<Item> itemsToDelete = new();
        
            foreach (ResourceEntity resourceEntity in ResourceHolderData.ResourceEntities)
            {
                List<Item> neededItems = inventory.Items.Where(x => x.name == resourceEntity.ResourceData.name).ToList();
            
                if (neededItems.Count < resourceEntity.ItemCount)
                {
                    itemsToDelete.Clear();
                    return false;
                }

                for (int i = 0; i < resourceEntity.ItemCount; i++)
                {
                    itemsToDelete.Add(neededItems[i]);
                }
            }

            foreach (Item itemToDelete in itemsToDelete)
            {
                inventory.RemoveItem(itemToDelete);
            }

            return true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }
            
            Inventory inventory = other.gameObject.GetComponent<Inventory>();
            if (inventory == null)
            {
                return;
            }
            
            bool isReceived = ReceiveItems(inventory);
            OnReceived?.Invoke(isReceived);
        }
    }
}