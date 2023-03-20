using System.Collections.Generic;
using Crafting.Recipy;

namespace Crafting.Crafter
{
    public interface ICrafter
    {
        List<RecipeData> RecipeDataList { get; set; }
        bool IsActivated { get; set; }

        void TryCraft(RecipeData recipeData);
    }
}