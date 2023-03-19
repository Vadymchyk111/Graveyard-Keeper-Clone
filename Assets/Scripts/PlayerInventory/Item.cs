using UnityEngine;

namespace PlayerInventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        //TODO maybe replace to? public string name = string.Empty;
        public new string name = "";
        public Sprite icon;
        public bool isDefault;
    }
}