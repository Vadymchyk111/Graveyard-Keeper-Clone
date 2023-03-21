using PlayerInventory;
using UnityEngine;

namespace Resourses.Generall
{
    [System.Serializable]
    public class ResourceEntity
    {
        [SerializeField] private Item _resourceData;
        [SerializeField] private int _count;

        public Item ResourceData => _resourceData;
        public int Count => _count;
    }
}
