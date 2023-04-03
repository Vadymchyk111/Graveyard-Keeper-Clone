using UnityEngine;
using Values.ScriptableObjects;

namespace PlayerInventory.ItemFolder
{
    [System.Serializable]
    public class ItemEntity
    {
        [SerializeField] private Item _item;
        [SerializeField] private ScriptableObjectInt _count;

        public Item Item => _item;

        public ScriptableObjectInt Count
        {
            get => _count;
            set => _count = value;
        }
    }
}