using UnityEngine;

namespace Resources.Generall
{
    [CreateAssetMenu(fileName = "DestructableResourceHolder", menuName = "ResourceHolder/DestructableResourceHolder")]
    public class DestructibleResourceHolderData : ResourceHolderData
    {
        [SerializeField] protected int _hitPoints;

        public int HitPoints => _hitPoints;
    }
}
