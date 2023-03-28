using PlayerInventory.Item;
using UnityEngine;

[CreateAssetMenu(fileName = "New EatableItem", menuName = "Item/EatableItem")]
public class EatableItem : Item
{
    [SerializeField] private float _starveRecoveryPoints;

    public float StarveRecoveryPoints => _starveRecoveryPoints; 
}
