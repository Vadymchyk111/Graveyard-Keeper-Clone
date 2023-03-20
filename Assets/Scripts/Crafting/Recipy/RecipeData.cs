using System.Collections.Generic;
using System.Linq;
using Collectable;
using PlayerInventory;
using UnityEngine;

namespace Crafting.Recipy
{
    [CreateAssetMenu(fileName = "RecipeData", menuName = "Recipe/NewRecipe")]
    public class RecipeData : ScriptableObject
    {
        [SerializeField] private RecipeElement[] _recipeElements;
        [SerializeField] private GameObject _craftedItem;
    
        public Item item;
    
        public GameObject TryCraft(Inventory inventory)
        {
            if (inventory.Collectables == null || inventory.Collectables.Count == 0)
            {
                return null;
            }

            List<ICollectable> itemsToDelete = new();
        
            foreach (RecipeElement recipeElement in _recipeElements)
            {
                List<ICollectable> neededItems = inventory.Collectables.Where(x => x.Item.name == recipeElement.Item.name).ToList();
            
                if (neededItems.Count < recipeElement.ItemCount)
                {
                    //TODO Add TextMeshPro to Inform the Player
                    return null;
                }

                for (int i = 0; i < recipeElement.ItemCount; i++)
                {
                    itemsToDelete.Add(neededItems[i]);
                }
            }

            foreach (ICollectable collectable in itemsToDelete)
            {
                inventory.RemoveItem(collectable);
            }

            return _craftedItem;
        }
    }
}
