using System;
using System.Collections.Generic;
using Collectable;
using UnityEngine;

namespace Crafting.Crafter
{
    public interface ICrafter
    {
        event Action<GameObject> OnCrafted;
        
        List<RecipeData> RecipeDataList { get; set; }
        bool IsActivated { get; set; }

        void TryCraft();
    }
}