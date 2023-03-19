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

        //todo remove unused
        private List<RecipeSlot> _recipeSlots;

        public void CreateCraftingSlots(List<RecipeData> recipes)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                GameObject recipeSlotObj = Instantiate(recipeSlotPrefab, recipeParent);
                RecipeSlot recipeSlot = recipeSlotObj.GetComponent<RecipeSlot>();
                recipeSlot.Init(recipes[i]);
                recipeSlot.OnRecipySelected += OnSelectRecipe;
            }
        }

        private void OnSelectRecipe(RecipeData recipeData)
        {
            OnSelectRecipeEvent?.Invoke(recipeData);
        }
    }
}