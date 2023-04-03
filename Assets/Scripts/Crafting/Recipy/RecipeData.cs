using System.Collections.Generic;
using System.Linq;
using PlayerInventory;
using PlayerInventory.ItemFolder;
using Resources.Generall;
using UnityEngine;

namespace Crafting.Recipy
{
    [CreateAssetMenu(fileName = "RecipeData", menuName = "Recipe/NewRecipe")]
    public class RecipeData : ScriptableObject
    {
        [SerializeField] private ResourceEntity[] _recipeElements;
        [SerializeField] private Item _item;

        public Item Item => _item;
    
        public Item TryCraft(Inventory inventory)
        {
            if (inventory.Items == null || inventory.Items.Count == 0)
            {
                return null;
            }

            List<Item> itemsToDelete = new();
        
            foreach (ResourceEntity recipeElement in _recipeElements)
            {
                List<Item> neededItems = inventory.Items.Where(x => x.name == recipeElement.ResourceData.Name).ToList();
            
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

            foreach (Item itemToDelete in itemsToDelete)
            {
                inventory.RemoveItem(itemToDelete);
            }

            return _item;
        }
    }
}
