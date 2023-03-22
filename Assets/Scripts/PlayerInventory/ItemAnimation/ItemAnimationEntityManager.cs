using PlayerInventory;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "ItemAnimationEntityManager", menuName = "Item/ItemAnimationEntityManager")]
public class ItemAnimationEntityManager : ScriptableObject
{
    [SerializeField] private ItemAnimationEntity[] _itemAnimationEntities;

    public string GetAnimationProperty(Item item)
    {
        string findedAnimationProperty = string.Empty;

        if(item != null && _itemAnimationEntities != null && _itemAnimationEntities.Length > 0)
        {
            findedAnimationProperty = _itemAnimationEntities.FirstOrDefault(x => x.ItemToLaunchAnimation == item).AnimationParametr;
        }

        return findedAnimationProperty;
    }
}
