using System;
using Collectable;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerInventory
{
    public class InventorySlot: MonoBehaviour
    {
        [SerializeField] private Image _icon;

        private Item _item;

        public void AddItem(ICollectable collectable)
        {
            _item = collectable.Item;
            
            _icon.sprite = collectable.Item.icon;
            _icon.enabled = true;
        }
        
        public void ClearItem()
        {
            _item = null;
            
            _icon.sprite = null;
            _icon.enabled = false;
        }
    }
}