using System;
using Collectable;
using PlayerInventory.ItemFolder;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerInventory
{
    public class InventorySlot: MonoBehaviour
    {
        public event Action<Item> OnInventorySelected;

        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        private Item _item;
        
        public Item Item => _item;

        private void OnEnable()
        {
            _button.onClick.AddListener(SendClickEvent);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SendClickEvent);
        }

        public void AddItem(Item item)
        {
            _item = item;
            
            _icon.sprite = _item.Icon;
            _icon.enabled = true;
        }
        
        public void ClearItem()
        {
            _item = null;
            
            _icon.sprite = null;
            _icon.enabled = false;
        }

        private void SendClickEvent()
        {
            OnInventorySelected?.Invoke(_item);
        }
    }
}