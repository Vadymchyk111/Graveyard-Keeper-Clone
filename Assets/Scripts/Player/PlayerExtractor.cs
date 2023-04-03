using System;
using System.Collections.Generic;
using Environment;
using Extractable;
using PlayerInventory;
using PlayerInventory.ItemAnimation;
using PlayerInventory.ItemFolder;
using Resources.Generall;
using UnityEngine;

namespace Player
{
    public class PlayerExtractor : MonoBehaviour, IExtractor
    {
        public event Action<List<Item>> OnExtracted;
        public event Action OnExtractHit;

        [SerializeField] private ItemAnimationEntityManager _itemAnimationEntityManager;
        [SerializeField] private PlayerController _playerController;

        private IExtractable _extractableResourceController;

        public bool StartExtract(IExtractable extractable)
        {
            if (extractable == null)
            {
                return false;
            }
            
            if (!_playerController.CheckEquipedInstrument(extractable))
            {
                return false;
            }

            _extractableResourceController = extractable;
            _extractableResourceController.OnExtracted += ExtractionCompleted;

            SetActiveExtractionAnimation(true, _extractableResourceController.Tool);

            return true;
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
            SetActiveExtractionAnimation(false, _extractableResourceController.Tool);
            _extractableResourceController = null;
        }

        public void ExtractionCompleted(ResourceEntity[] resourceEntities)
        {
            List<Item> items = new List<Item>();
        
            foreach (ResourceEntity resourceEntity in resourceEntities)
            {
                for (int i = 0; i < resourceEntity.ItemCount; i++)
                {
                    items.Add(resourceEntity.ResourceData);
                }
            }
        
            OnExtracted?.Invoke(items);
            StopExtract();
        }

        private void SetActiveExtractionAnimation(bool isActive, Item item)
        {
            string animationParameter = _itemAnimationEntityManager.GetAnimationProperty(item);

            if(!string.IsNullOrEmpty(animationParameter))
            {
                _playerController.AnimationController.SetExtraction(isActive, animationParameter);
            }
        }

        public void HitExtract()
        {
            OnExtractHit?.Invoke();
        }
    }
}
