using System;
using System.Collections.Generic;
using Crafting.Recipy;
using UnityEngine;

namespace Crafting.Crafter
{
    public class CraftingUI : MonoBehaviour
    {
        [SerializeField] private Transform recipeParent;
        [SerializeField] private GameObject recipeSlotPrefab;

        private List<RecipeSlot> _recipeSlots;

        public void CreateCraftingSlots(List<RecipeData> recipes)
        {
            foreach (RecipeData recipeData in recipes)
            {
                GameObject recipeSlotObj = Instantiate(recipeSlotPrefab, recipeParent);
                RecipeSlot recipeSlot = recipeSlotObj.GetComponent<RecipeSlot>();
                recipeSlot.AddItem(recipeData.item);
            }
        }
    }
}