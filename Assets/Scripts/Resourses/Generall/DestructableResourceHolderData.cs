using UnityEngine;

[CreateAssetMenu(fileName = "DestructableResourceData", menuName = "ScriptableObjects/DestructableResourceData")]
public class DestructableResourceHolderData : ResourceHolderData
{
    [SerializeField] protected int _hitPoints;
    public int HitPoints => _hitPoints;
}
