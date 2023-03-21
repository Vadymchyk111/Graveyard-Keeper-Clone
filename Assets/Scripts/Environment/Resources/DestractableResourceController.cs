using System;
using System.Collections;
using General;
using Resourses.Generall;
using UnityEngine;

namespace Environment.Tree
{
    public class DestractableResourceController : MonoBehaviour, IExtractable
    {
        public event Action<ResourceEntity[]> OnExtracted;
        
        [SerializeField] private DestructibleResourceHolderData _destructibleResourceHolderData;
        [SerializeField] private float _delayBeforeHitInSeconds;
        
        private Coroutine extracting;
        private WaitForSeconds _waitForSeconds;
        private int _hitPoints;

        public bool IsEmpty { get; set; }

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

            extracting = StartCoroutine(ExtractingCoroutine());
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
