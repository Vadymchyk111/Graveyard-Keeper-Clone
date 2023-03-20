using System;
using System.Collections.Generic;
using Collectable;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerInventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action OnInventoryChanged;

        [SerializeField] private GameObject _inventoryPanel;
        
        private PlayerInputActionsAsset _playerInputActionsAsset;
        private readonly List<ICollectable> _collectables = new();
        
        public static Inventory instance;

        public bool IsActivated { get; set; }
        public List<ICollectable> Collectables => _collectables;
        public int InventorySize => _collectables.Count;

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

        public void AddItem(ICollectable collectable)
        {
            _collectables.Add(collectable);
            OnInventoryChanged?.Invoke();
        }
        
        public void RemoveItem(ICollectable collectable)
        {
            _collectables.Remove(collectable);
        }
        
        private void SetActiveCraftingPanel(InputAction.CallbackContext context)
        {
            IsActivated = !IsActivated;
            _inventoryPanel.SetActive(IsActivated);
        }
    }
}