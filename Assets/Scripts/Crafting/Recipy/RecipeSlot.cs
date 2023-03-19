using Collectable;
using PlayerInventory;
using UnityEngine;
using UnityEngine.UI;

namespace Crafting.Recipy
{
    public class RecipeSlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        private Item _item;
        private RecipeData _recipe;

        public void AddItem(Item item)
        {
            _item = item;
            
            _icon.sprite = _item.icon;
            _icon.enabled = true;
        }
    }
}