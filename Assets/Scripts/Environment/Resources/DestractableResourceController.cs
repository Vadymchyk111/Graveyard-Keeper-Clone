using System;
using System.Collections;
using Extractable;
using General;
using PlayerInventory;
using PlayerInventory.Item;
using Resourses.Generall;
using UnityEngine;

namespace Environment.Resources
{
    public class DestractableResourceController : MonoBehaviour, IExtractable
    {
        public event Action<ResourceEntity[]> OnExtracted;
        
        [SerializeField] private DestructibleResourceHolderData _destructibleResourceHolderData;
        [SerializeField] private float _delayBeforeHitInSeconds;
        [SerializeField] private Item _tool;
        
        private Coroutine extracting;
        private WaitForSeconds _waitForSeconds;
        private int _hitPoints;

        public bool IsEmpty { get; set; }
        public Item Tool => _tool;

        private void Start()
        {
            _hitPoints = _destructibleResourceHolderData.HitPoints; 
            _waitForSeconds = new WaitForSeconds(_delayBeforeHitInSeconds);
        }

        public void StartExtracting(IExtractor extractor)
        {
            extractor.StartExtract(this);

            if (extracting != null)
            {
                StopCoroutine(extracting);
            }

            if (_hitPoints > 0)
            {
                extracting = StartCoroutine(ExtractingCoroutine());
            }
        }

        public void StopExtracting(IExtractor extractor)
        {
            extractor.StopExtract();
            if (extracting != null)
            {
                StopCoroutine(extracting);
            }
        }

        private IEnumerator ExtractingCoroutine()
        {
            while (_hitPoints > 0)
            {
                yield return _waitForSeconds;
                _hitPoints--;
            }

            OnExtracted?.Invoke(_destructibleResourceHolderData.ResourceEntities);
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

            StartExtracting(extractor);
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

            StopExtracting(extractor);
        }
    }
}
