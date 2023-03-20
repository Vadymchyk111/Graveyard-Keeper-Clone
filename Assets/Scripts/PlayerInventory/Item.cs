using UnityEngine;

namespace PlayerInventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public new string name = string.Empty;
        public Sprite icon;
        public bool isDefault;
    }
}