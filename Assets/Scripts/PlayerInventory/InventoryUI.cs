using UnityEngine;

namespace PlayerInventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _inventorySlots; 
            
        private Inventory _inventory;

        private void Start()
        {
            _inventory = Inventory.instance;
            _inventory.OnInventoryChanged += UpdateUI;
        }

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