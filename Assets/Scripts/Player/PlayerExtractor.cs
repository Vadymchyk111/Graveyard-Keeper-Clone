using System;
using System.Collections.Generic;
using Environment;
using PlayerInventory;
using Resourses.Generall;
using UnityEngine;

namespace Player
{
    public class PlayerExtractor : MonoBehaviour, IExtractor
    {
        public event Action<List<Item>> OnExtracted;
        public event Action OnExtracting;

        [SerializeField] private PlayerController _playerController;

        private IExtractable _extractableResourceController;

        public void StartExtract(IExtractable extractable)
        {
            if (extractable == null)
            {
                return;
            }
            
            if (!_playerController.CheckEquipedInstrument(extractable))
            {
                return;
            }
            
            OnExtracting?.Invoke();
            _extractableResourceController = extractable;
            _extractableResourceController.OnExtracted += ExtractionCompleted;
        }

        public void StopExtract()
        {
            if (_extractableResourceController == null)
            {
                return;
            }
            
            if (!_playerController.CheckEquipedInstrument(_extractableResourceController))
            {
                return;
            }
                
            _extractableResourceController.OnExtracted -= ExtractionCompleted;
            _extractableResourceController = null;
        }

        public void ExtractionCompleted(ResourceEntity[] resourceEntities)
        {
            List<Item> items = new List<Item>();
        
            foreach (ResourceEntity resourceEntity in resourceEntities)
            {
                for (int i = 0; i < resourceEntity.Count; i++)
                {
                    items.Add(resourceEntity.ResourceData);
                }
            }
        
            OnExtracted?.Invoke(items);
        }
    }
}
