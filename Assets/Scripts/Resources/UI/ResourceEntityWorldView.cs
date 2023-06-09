using Resources.Generall;
using TMPro;
using UnityEngine;

namespace Resources.UI
{
    public class ResourceEntityWorldView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private TextMeshPro _textMesh;

        public void Init(ResourceEntity resourceEntity)
        {
            _renderer.sprite = resourceEntity.ResourceData.Icon;
            _textMesh.text = $"{resourceEntity.ResourceData.Name}: {resourceEntity.ItemCount}";
        }
    }
}