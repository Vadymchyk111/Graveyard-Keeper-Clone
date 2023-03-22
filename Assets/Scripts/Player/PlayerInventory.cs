using PlayerInventory;
using Tools;
using Tools.Generall;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private ToolManager _toolManager;

        private Item _currentItem;
        
        public bool IsEquipedItem { get; set; }
        public Item CurrentInstrument => _currentItem;

        private void OnEnable()
        {
            _inventory.OnUseItem += AttachObject;
        }

        private void OnDisable()
        {
            _inventory.OnUseItem -= AttachObject;
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
            tool?.Equip();
        }

        private void DetachObject()
        {
            if (_currentItem == null)
            {
                return;
            }

            ITool tool = _toolManager.GetTool(_currentItem);
            tool?.UnEquip();
        }
    }
}
