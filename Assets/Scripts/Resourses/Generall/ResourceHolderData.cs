using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "ScriptableObjects/ResourceData")]
public class ResourceHolderData : ScriptableObject
{
    [SerializeField] protected ResourceEntity[] _resourceEntities;
    public ResourceEntity[] ResourceEntities=> _resourceEntities;
}
