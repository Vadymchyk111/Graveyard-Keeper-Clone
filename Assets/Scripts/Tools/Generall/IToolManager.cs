using PlayerInventory;
using PlayerInventory.ItemFolder;

namespace Tools.Generall
{
    public interface IToolManager 
    {
        ITool GetTool(Item item);
    }
}
