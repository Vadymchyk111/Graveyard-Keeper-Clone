using UnityEngine;

namespace Resourses.Generall
{
    [CreateAssetMenu(fileName = "ResourceHolder", menuName = "ResourceHolder/ResourceHolder")]
    public class ResourceHolderData : ScriptableObject
    {
        [SerializeField] protected ResourceEntity[] _resourceEntities;
        public ResourceEntity[] ResourceEntities => _resourceEntities;
    }
}
