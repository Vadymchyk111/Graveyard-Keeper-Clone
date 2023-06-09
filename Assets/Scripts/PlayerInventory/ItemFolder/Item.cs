using UnityEngine;

namespace PlayerInventory.ItemFolder
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private new string name = string.Empty;
        [SerializeField] private Sprite icon;

        public string Name => name;
        public Sprite Icon => icon;
    }
}