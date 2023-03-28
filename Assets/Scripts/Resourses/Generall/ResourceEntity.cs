using PlayerInventory;
using PlayerInventory.Item;
using UnityEngine;

namespace Resourses.Generall
{
    [System.Serializable]
    public class ResourceEntity
    {
        [SerializeField] private Item _resourceData;
        [SerializeField] private int _itemCount;

        public Item ResourceData => _resourceData;
        public int ItemCount => _itemCount;
    }
}
