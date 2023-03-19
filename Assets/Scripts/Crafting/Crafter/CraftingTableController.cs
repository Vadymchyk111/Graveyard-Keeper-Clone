using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Collectable;
using Crafting.Crafter;
using PlayerInventory;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTableController : MonoBehaviour, ICrafter
{
    [SerializeField] private GameObject _craftingPanel;
    [SerializeField] private List<RecipeData> recipeDataList;
    
    private Inventory _inventory;
    private RecipeData _currentRecipe;
    
    public event Action<GameObject> OnCrafted;
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

    private void Start()
    {
        _inventory = Inventory.instance;
        _craftingPanel.GetComponentInParent<CraftingUI>().CreateCraftingSlots(RecipeDataList);
    }

    public void TryCraft()
    {
        _currentRecipe = recipeDataList[0];
        GameObject craftedObject = _currentRecipe.TryCraft(_inventory);
        
        if (craftedObject == null)
        {
            return;
        }
        
        ICollectable collectable = craftedObject.GetComponent<ICollectable>();
        _inventory.AddItem(collectable);
    }

    public void SetActiveCraftingPanel(bool isActive)
    {
        _craftingPanel.SetActive(isActive);
    }

    private void SetCurrentRecipe(RecipeData recipeData)
    {
        _currentRecipe = recipeData;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsActivated = true;
            SetActiveCraftingPanel(IsActivated);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsActivated = false;
            SetActiveCraftingPanel(IsActivated);
        }
    }
}