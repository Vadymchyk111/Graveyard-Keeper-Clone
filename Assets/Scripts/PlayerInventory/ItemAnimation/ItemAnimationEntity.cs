using PlayerInventory.ItemFolder;
using UnityEngine;

namespace PlayerInventory.ItemAnimation
{
    [System.Serializable]
    public class ItemAnimationEntity
    {
        [SerializeField] private Item _itemToLaunchAnimation;
        [SerializeField] private string _animationParameter;

        public Item ItemToLaunchAnimation => _itemToLaunchAnimation;
        public string AnimationParameter => _animationParameter;
    }
}
