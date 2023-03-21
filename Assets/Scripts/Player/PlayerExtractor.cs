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

        [SerializeField] private TreeController _treeController;

        private void OnEnable()
        {
            _treeController.OnExtracted += ExtractionCompleted;
        }

        private void OnDisable()
        {
            _treeController.OnExtracted -= ExtractionCompleted;
        }

        public void StartExtract()
        {
            //TODO add check equiped axe
            //if axe equiped start animation
        }

        public void StopExtract()
        {
            //TODO add check equiped axe
            //if axe equiped stop animation
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
