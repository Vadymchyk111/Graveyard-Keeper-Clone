using System.Collections.Generic;
using System.Linq;
using Collectable;
using Crafting.Recipy;
using PlayerInventory;
using UnityEngine;

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

        foreach (RecipeElement recipeElement in _recipeElements)
        {
            int neededItems = inventory.Collectables.Count(x => x.Item.name == recipeElement.Item.name);

            if (neededItems < recipeElement.ItemCount)
            {
                return null;
            }

            for (int i = 0; i < recipeElement.ItemCount; i++)
            {
                inventory.RemoveItem(
                    inventory.Collectables.FirstOrDefault(x => x.Item.name == recipeElement.Item.name));
            }
        }
        
        return _craftedItem;
    }
}
