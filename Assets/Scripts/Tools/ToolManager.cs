using PlayerInventory;
using UnityEngine;
using System.Linq;

public class ToolManager : MonoBehaviour, IToolManager
{
    [SerializeField] private Tool[] _tools;

    void Start()
    {
        DeactivateAllTools();
    }

    public ITool GetTool(Item item)
    {
        ITool tool = null;

        if(item != null && _tools!=null && _tools.Length > 0)
        {
            tool = _tools.FirstOrDefault(x => x.Id == item.name);
        }

        return tool;
    }

    private void DeactivateAllTools()
    {
        foreach(var tool in _tools)
        {
            tool.UnEquip();
        }
    }
}