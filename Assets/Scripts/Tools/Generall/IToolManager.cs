using PlayerInventory;
using PlayerInventory.Item;

namespace Tools.Generall
{
    public interface IToolManager 
    {
        ITool GetTool(Item item);
    }
}
