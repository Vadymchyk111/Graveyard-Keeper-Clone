using UnityEngine;

namespace Resourses.Generall
{
    [CreateAssetMenu(fileName = "DestructableResourceData", menuName = "ScriptableObjects/DestructableResourceData")]
    public class DestructibleResourceHolderData : ResourceHolderData
    {
        [SerializeField] protected int _hitPoints;

        public int HitPoints
        {
            get => _hitPoints;
            set => _hitPoints = value;
        }
    }
}
