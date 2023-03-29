using System;
using System.Collections;
using System.Collections.Generic;
using PlayerInventory.Item;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerInventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action<Item.Item> OnUseItem;
        public event Action OnInventoryChanged;

        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private ItemEntityHolder _itemEntityHolder;
        
        private PlayerInputActionsAsset _playerInputActionsAsset;
        private readonly List<Item.Item> items = new();

        public bool IsActivated { get; set; }
        public List<Item.Item> Items => items;
        public int InventorySize => items.Count;

        private void Awake()
        {
            _playerInputActionsAsset = new PlayerInputActionsAsset();
            _inventoryPanel.SetActive(false);
        }

        private void OnEnable()
        {
            _playerInputActionsAsset.Player.OpenInventory.performed += SetActiveCraftingPanel;
            _playerInputActionsAsset.Player.OpenInventory.Enable();
        }

        private void OnDisable()
        {
            _playerInputActionsAsset.Player.OpenInventory.performed -= SetActiveCraftingPanel;
            _playerInputActionsAsset.Player.OpenInventory.Disable();
        }

        public void AddItem(Item.Item item, bool impactOnSaves = true)
        {
            items.Add(item);
            
            if (impactOnSaves)
            {
                _itemEntityHolder.AddItems(item, 1);
            }
            
            OnInventoryChanged?.Invoke();
        }
        
        public void RemoveItem(Item.Item item, bool impactOnSaves = true)
        {
            items.Remove(item);
            
            if (impactOnSaves)
            {
                _itemEntityHolder.RemoveItems(item, 1);
            }
            
            OnInventoryChanged?.Invoke();
        }

        public void UseItem(Item.Item item)
        {
            OnUseItem?.Invoke(item);
        }

        private void SetActiveCraftingPanel(InputAction.CallbackContext context)
        {
            IsActivated = !IsActivated;
            _inventoryPanel.SetActive(IsActivated);
        }

        public void Init(Action<Inventory> onInited)
        {
            foreach (ItemEntity itemEntity in _itemEntityHolder.ItemEntities)
            {
                for (int i = 0; i < itemEntity.Count.Value.RestoreValue(); i++)
                {
                    AddItem(itemEntity.Item, false);
                }
            }
            
            onInited?.Invoke(this);
        }
    }
}