using PlayerInventory.ItemFolder;
using UnityEngine;

namespace PlayerInventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _inventorySlots; 
            
        private Inventory _inventory;
        
        private void OnDestroy()
        {
            _inventory.OnInventoryChanged -= UpdateUI;
        }

        private void UpdateUI()
        {
            if (_inventorySlots is not { Length: > 0 })
            {
                return;
            }
            
            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                if (i < _inventory.Items.Count)
                {
                    if (_inventorySlots[i].Item == null)
                    {
                        _inventorySlots[i].OnInventorySelected += SelectInventory;
                    }
                    
                    _inventorySlots[i].AddItem(_inventory.Items[i]);
                }
                else
                {
                    _inventorySlots[i].ClearItem();
                    _inventorySlots[i].OnInventorySelected -= SelectInventory;
                }
            }
        }

        private void SelectInventory(Item item)
        {
            _inventory.UseItem(item);
        }

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
            UpdateUI();
            _inventory.OnInventoryChanged += UpdateUI;
        }
    }
}