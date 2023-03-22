using System.Collections;
using System.Collections.Generic;
using PlayerInventory;
using UnityEngine;

[System.Serializable]
public class ItemAnimationEntity
{
    [SerializeField] private Item _itemToLaunchAnimation;
    [SerializeField] private string _animationParametr;

    public Item ItemToLaunchAnimation => _itemToLaunchAnimation;
    public string AnimationParametr => _animationParametr;
}
