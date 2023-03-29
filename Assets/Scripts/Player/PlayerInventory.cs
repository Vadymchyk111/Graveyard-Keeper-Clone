using System;
using PlayerInventory;
using PlayerInventory.Item;
using Tools;
using Tools.Generall;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private InventoryUI _inventoryUI;
        [SerializeField] private ToolManager _toolManager;

        private Inventory _inventory;
        private Item _currentItem;
        
        public bool IsEquipedItem { get; set; }
        public Item CurrentInstrument => _currentItem;

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }

        private void OnEnable()
        {
            _inventory.OnUseItem += AttachObject;
        }

        private void OnDisable()
        {
            _inventory.OnUseItem -= AttachObject;
        }

        private void Start()
        {
            _inventory.Init(_inventoryUI.Init);
        }

        private void AttachObject(Item item)
        {
            if (item == _currentItem)
            {
                DetachObject();
                _currentItem = null;
                return;
            }
            
            if(item == null)
            {
                return;
            }

            //detach prev tool
            DetachObject();
            _currentItem = item;

            ITool tool = _toolManager.GetTool(item);

            if(tool == null)
            {
                return;
            }

            tool.Equip();
        }

        private void DetachObject()
        {
            if (_currentItem == null)
            {
                return;
            }

            ITool tool = _toolManager.GetTool(_currentItem);

            if (tool == null)
            {
                return;
            }

            tool.UnEquip();
        }
    }
}
