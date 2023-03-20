using System;
using System.Collections.Generic;
using Crafting.Recipy;
using Crafting.Recipy.UI;
using UnityEngine;

namespace Crafting.Crafter
{
    public class CraftingUI : MonoBehaviour
    {
        public event Action<RecipeData> OnSelectRecipeEvent;
        
        [SerializeField] private Transform recipeParent;
        [SerializeField] private GameObject recipeSlotPrefab;
        
        public void CreateCraftingSlots(List<RecipeData> recipes)
        {
            foreach (RecipeData recipeData in recipes)
            {
                GameObject recipeSlotObj = Instantiate(recipeSlotPrefab, recipeParent);
                RecipeSlot recipeSlot = recipeSlotObj.GetComponent<RecipeSlot>();
                recipeSlot.Init(recipeData);
                recipeSlot.OnRecipySelected += OnSelectRecipe;
            }
        }

        private void OnSelectRecipe(RecipeData recipeData)
        {
            OnSelectRecipeEvent?.Invoke(recipeData);
        }
    }
}