using PlayerInventory;
using UnityEngine;

namespace Crafting.Recipy
{
    [System.Serializable]
    public class RecipeElement
    {
        [SerializeField] private Item _item;
        [SerializeField] private int _itemCount;

        public Item Item => _item;
        public int ItemCount => _itemCount;
    }
}