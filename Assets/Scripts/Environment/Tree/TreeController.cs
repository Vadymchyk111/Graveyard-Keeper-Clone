using System;
using System.Collections;
using Resourses.Generall;
using UnityEngine;
using static General.Contants;

namespace Environment.Tree
{
    public class TreeController : MonoBehaviour, IExtractable
    {
        public event Action<ResourceEntity[]> OnExtracted;
        
        [SerializeField] private DestructibleResourceHolderData _destructibleResourceHolderData;
        [SerializeField] private float _timeToDestroy;
        
        private Coroutine extracting;
        private WaitForSeconds _waitForSeconds;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_timeToDestroy);
        }

        public bool IsEmpty { get; set; }

        public void StartExtracting(IExtractor extractor)
        {
            extractor.StartExtract();
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
            int hitPoints = _destructibleResourceHolderData.HitPoints;

            while (hitPoints > 0)
            {
                yield return _waitForSeconds;
                hitPoints--;
            }

            OnExtracted?.Invoke(_destructibleResourceHolderData.ResourceEntities);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(PLAYER_TAG))
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
            if (!other.gameObject.CompareTag(PLAYER_TAG))
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
