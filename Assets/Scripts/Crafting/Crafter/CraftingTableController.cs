using System.Collections.Generic;
using Collectable;
using Crafting.Recipy;
using PlayerInventory;
using UnityEngine;
using static General.Contants;

namespace Crafting.Crafter
{
    public class CraftingTableController : MonoBehaviour, ICrafter
    {
        [SerializeField] private GameObject _craftingPanel;
        [SerializeField] private List<RecipeData> recipeDataList;
        [SerializeField] private CraftingUI _craftingUI;

        private Inventory _inventory;
        private RecipeData _currentRecipe;

        public bool IsActivated { get; set; }
        public List<RecipeData> RecipeDataList 
        { 
            get => recipeDataList;
            set => recipeDataList = value; 
        }
    
        private void Awake()
        {
            SetActiveCraftingPanel(IsActivated);
        }

        private void OnEnable()
        {
            _craftingUI.OnSelectRecipeEvent += TryCraft;
        }

        private void OnDisable()
        {
            _craftingUI.OnSelectRecipeEvent -= TryCraft;
        }

        private void Start()
        {
            _inventory = Inventory.instance;
            _craftingUI.CreateCraftingSlots(RecipeDataList);
        }

        public void TryCraft(RecipeData recipeData)
        {
            _currentRecipe = recipeData;

            Item craftedItem = _currentRecipe.TryCraft(_inventory);

            if (craftedItem != null)
            {
                _inventory.AddItem(craftedItem);
            }
        }

        private void SetActiveCraftingPanel(bool isActive)
        {
            _craftingPanel.SetActive(isActive);
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(PLAYER_TAG))
            {
                return;
            }
        
            IsActivated = true;
            SetActiveCraftingPanel(IsActivated);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag(PLAYER_TAG))
            {
                return;
            }
        
            IsActivated = false;
            SetActiveCraftingPanel(IsActivated);
        }
    }
}