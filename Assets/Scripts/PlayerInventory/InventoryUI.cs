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
            //TODO move to OnEnable, add _inventory.OnInventoryChanged -= UpdateUI; to OnDisable
            _inventory.OnInventoryChanged += UpdateUI;
            //TODO asign is Editor with [SerializeField] private InventorySlot[]
            _inventorySlots = itemParent.GetComponentsInChildren<InventorySlot>();
        }

        private void UpdateUI()
        {
            //TODO add check _inventorySlots is not null and _inventorySlots.Length > 0
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