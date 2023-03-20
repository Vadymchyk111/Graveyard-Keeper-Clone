using System;
using PlayerInventory;
using UnityEngine;
using UnityEngine.UI;

namespace Crafting.Recipy.UI
{
    public class RecipeSlot : MonoBehaviour
    {
        public event Action<RecipeData> OnRecipySelected;
        
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        private Item _item;
        private RecipeData _recipe;

        private void OnEnable()
        {
            _button.onClick.AddListener(SendClickEvent);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SendClickEvent);
        }

        private void AddItem(Item item)
        {
            _item = item;
            _icon.sprite = _item.icon;
            _icon.enabled = true;
        }

        public void Init(RecipeData recipe)
        {
            _recipe = recipe;
            AddItem(_recipe.item);
        }

        private void SendClickEvent()
        {
            OnRecipySelected?.Invoke(_recipe);
        }
    }
}