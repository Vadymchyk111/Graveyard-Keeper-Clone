using Collectable;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerInventory
{
    public class InventorySlot: MonoBehaviour
    {
        [SerializeField] private Image _icon;

        private Item _item;

        public void AddItem(Item item)
        {
            _item = item;
            
            _icon.sprite = _item.icon;
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