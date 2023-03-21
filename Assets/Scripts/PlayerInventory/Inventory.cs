using System;
using System.Collections.Generic;
using Collectable;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerInventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action<Item> OnUseItem;
        public event Action OnInventoryChanged;

        [SerializeField] private GameObject _inventoryPanel;
        
        private PlayerInputActionsAsset _playerInputActionsAsset;
        private readonly List<Item> items = new();
        
        public static Inventory instance;

        public bool IsActivated { get; set; }
        public List<Item> Items => items;
        public int InventorySize => items.Count;

        private void Awake()
        {
            instance = this;
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

        public void AddItem(Item item)
        {
            items.Add(item);
            OnInventoryChanged?.Invoke();
        }
        
        public void RemoveItem(Item item)
        {
            items.Remove(item);
            OnInventoryChanged?.Invoke();
        }

        public void UseItem(Item item)
        {
            OnUseItem?.Invoke(item);
        }

        private void SetActiveCraftingPanel(InputAction.CallbackContext context)
        {
            IsActivated = !IsActivated;
            _inventoryPanel.SetActive(IsActivated);
        }
    }
}