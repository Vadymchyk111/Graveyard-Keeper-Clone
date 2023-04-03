using System;
using System.Collections;
using Extractable;
using General;
using PlayerInventory.ItemFolder;
using Resources.Generall;
using UnityEngine;

namespace Environment.Resources
{
    public class DestractableResourceController : MonoBehaviour, IExtractable
    {
        public event Action<ResourceEntity[]> OnExtracted;
        
        [SerializeField] private DestructibleResourceHolderData _destructibleResourceHolderData;
        [SerializeField] private Item _tool;
        [SerializeField] private ParticleSystem _particleSystem;
        
        private Coroutine extracting;
        private int _hitPoints;
        private IExtractor _extractor;

        public bool IsEmpty { get; set; }
        public Item Tool => _tool;

        private void Start()
        {
            _hitPoints = _destructibleResourceHolderData.HitPoints;
        }

        private void DoExtractHit()
        {
            if (_hitPoints > 0)
            {
                _hitPoints--;
                _particleSystem.Play();
                return;
            }

            OnExtracted?.Invoke(_destructibleResourceHolderData.ResourceEntities);
            _extractor.OnExtractHit -= DoExtractHit;
            _extractor.StopExtract();
            _extractor = null;
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(Contants.PLAYER_TAG))
            {
                return;
            }

            IExtractor extractor = other.gameObject.GetComponent<IExtractor>();

            if(extractor == null)
            {
                return;
            }

            extractor.StartExtract(this);
            _extractor = extractor;
            extractor.OnExtractHit += DoExtractHit;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag(Contants.PLAYER_TAG))
            {
                return;
            }
        
            IExtractor extractor = other.gameObject.GetComponent<IExtractor>();

            if (extractor == null)
            {
                return;
            }

            extractor.StopExtract();
            _extractor = null;
            extractor.OnExtractHit -= DoExtractHit;
        }
    }
}
