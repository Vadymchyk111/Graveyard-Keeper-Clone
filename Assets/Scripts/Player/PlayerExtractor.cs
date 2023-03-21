using System;
using System.Collections.Generic;
using Environment;
using Environment.Tree;
using PlayerInventory;
using Resourses.Generall;
using UnityEngine;

namespace Player
{
    public class PlayerExtractor : MonoBehaviour, IExtractor
    {
        public event Action<List<Item>> OnExtracted;

        private IExtractable _extractableResourceController;

        public void StartExtract(IExtractable extractable)
        {
            //TODO add check equiped axe
            //if axe equiped start animation

            if(extractable != null)
            {
                _extractableResourceController = extractable;
                _extractableResourceController.OnExtracted += ExtractionCompleted;
            }
        }

        public void StopExtract()
        {
            //TODO add check equiped axe
            //if axe equiped stop animation
            if (_extractableResourceController != null)
            {
                _extractableResourceController.OnExtracted -= ExtractionCompleted;
                _extractableResourceController = null;
            }
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
