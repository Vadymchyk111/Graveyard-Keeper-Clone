using System.Collections.Generic;
using UnityEngine;

namespace PlayerInventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform itemParent;

        private InventorySlot[] _inventorySlots; 
            
        private Inventory _inventory;

        private void Start()
        {
            _inventory = Inventory.instance;
            _inventory.OnInventoryChanged += UpdateUI;
            _inventorySlots = itemParent.GetComponentsInChildren<InventorySlot>();
        }

        private void UpdateUI()
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                if (i < _inventory.Collectables.Count)
                {
                    _inventorySlots[i].AddItem(_inventory.Collectables[i]);
                }
                else
                {
                    _inventorySlots[i].ClearItem();
                }
            }
        }
    }
}