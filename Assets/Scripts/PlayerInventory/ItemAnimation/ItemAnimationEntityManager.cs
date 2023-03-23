using System.Linq;
using UnityEngine;

namespace PlayerInventory.ItemAnimation
{
    [CreateAssetMenu(fileName = "ItemAnimationEntityManager", menuName = "Item/ItemAnimationEntityManager")]
    public class ItemAnimationEntityManager : ScriptableObject
    {
        [SerializeField] private ItemAnimationEntity[] _itemAnimationEntities;

        public string GetAnimationProperty(Item.Item item)
        {
            string findedAnimationProperty = string.Empty;

            if(item != null && _itemAnimationEntities is { Length: > 0 })
            {
                findedAnimationProperty = _itemAnimationEntities.FirstOrDefault(x => x.ItemToLaunchAnimation == item)?.AnimationParameter;
            }

            return findedAnimationProperty;
        }
    }
}
