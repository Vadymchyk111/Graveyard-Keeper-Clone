using UnityEngine;
using Values.ScriptableObjects;

namespace PlayerInventory.ItemFolder
{
    [System.Serializable]
    public class EatableItemEntity
    {
        [SerializeField] private EatableItem _item;
        [SerializeField] private ScriptableObjectInt _count;

        public EatableItem Item => _item;

        public ScriptableObjectInt Count
        {
            get => _count;
            set => _count = value;
        }
    }
}