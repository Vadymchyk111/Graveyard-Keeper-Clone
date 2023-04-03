using UnityEngine;

namespace PlayerInventory.ItemFolder
{
    [CreateAssetMenu(fileName = "New EatableItem", menuName = "Item/EatableItem")]
    public class EatableItem : Item
    {
        [SerializeField] private float _starveRecoveryPoints;

        public float StarveRecoveryPoints => _starveRecoveryPoints; 
    }
}
