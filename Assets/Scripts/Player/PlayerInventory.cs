using PlayerInventory;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private ToolManager _toolManager;

        private Item _currentItem;

        private void OnEnable()
        {
            _inventory.OnUseItem += AttachObject;
        }

        private void OnDisable()
        {
            _inventory.OnUseItem -= AttachObject;
        }

        public void AttachObject(Item item)
        {
            if(item == null)
            {
                return;
            }

            //detach prev tool
            DetachObject();
            _currentItem = item;

            ITool tool = _toolManager.GetTool(item);
            tool.Equip();
        }

        public void DetachObject()
        {
            if (_currentItem == null)
            {
                return;
            }

            ITool tool = _toolManager.GetTool(_currentItem);
            tool.UnEquip();
        }
    }
}
