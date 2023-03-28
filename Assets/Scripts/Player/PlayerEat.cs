using System;
using Collectable;
using Eatable;
using PlayerInventory;
using PlayerInventory.Item;
using UnityEngine;

namespace Player
{
    public class PlayerEat : MonoBehaviour
    {
        public event Action<float> OnRecoveryStarve;
        [SerializeField] private Inventory _inventory;

        private void OnEnable()
        {
            _inventory.OnUseItem += TryToEat;
        }

        private void OnDisable()
        {
            _inventory.OnUseItem -= TryToEat;
        }

        private void TryToEat(Item item)
        {
            EatableItem eatableItem = item as EatableItem;

            if (eatableItem == null)
            {
                return;
            }

            OnRecoveryStarve?.Invoke(eatableItem.StarveRecoveryPoints);
            _inventory.RemoveItem(item);
        }
    }
}