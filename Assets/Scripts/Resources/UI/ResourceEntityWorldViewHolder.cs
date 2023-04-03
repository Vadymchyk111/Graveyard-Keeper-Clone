using ReceiverObjects;
using Resources.Generall;
using UnityEngine;

namespace Resources.UI
{
    public class ResourceEntityWorldViewHolder : MonoBehaviour
    {
        [SerializeField] private ResourceHolderData _holderData;
        [SerializeField] private ResourceEntityWorldView[] _resourceEntities;
        [SerializeField] private ReceiverBase _receiverBase;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            _receiverBase.OnReceived += SetActive;
        }

        private void OnDisable()
        {
            _receiverBase.OnReceived -= SetActive;
        }

        private void Init()
        {
            for (int i = 0; i < _holderData.ResourceEntities.Length; i++)
            {
                _resourceEntities[i].Init(_holderData.ResourceEntities[i]);
            }
        }

        private void SetActive(bool isReceived)
        {
            gameObject.SetActive(!isReceived);
        }
    }
}