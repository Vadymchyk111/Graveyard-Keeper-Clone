using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayerInventory.ItemFolder
{
    [CreateAssetMenu(fileName = "ItemEntityHolder", menuName = "Items/ItemEntityHolder")]
    public class ItemEntityHolder : ScriptableObject
    {
        [SerializeField] private List<ItemEntity> _itemEntities;

        public List<ItemEntity> ItemEntities => _itemEntities;

        public void AddItems(Item item, int itemCount)
        {
            ItemEntity itemEntity = _itemEntities.FirstOrDefault(x => x.Item.Name == item.Name);
            itemEntity?.Count.ChangeValue(itemEntity.Count.Value.Value + itemCount, true);
        }

        public void RemoveItems(Item item, int itemCount)
        {
            ItemEntity itemEntity = _itemEntities.FirstOrDefault(x => x.Item.Name == item.Name);
            itemEntity?.Count.ChangeValue(itemEntity.Count.Value.Value - itemCount, true);
        }
    }
}