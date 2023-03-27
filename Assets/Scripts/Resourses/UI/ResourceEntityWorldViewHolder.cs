using System;
using Resourses.Generall;
using UnityEngine;

namespace Resourses.UI
{
    public class ResourceEntityWorldViewHolder : MonoBehaviour
    {
        [SerializeField] private ResourceHolderData _holderData;
        [SerializeField] private ResourceEntityWorldView[] _resourceEntities;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < _holderData.ResourceEntities.Length; i++)
            {
                _resourceEntities[i].Init(_holderData.ResourceEntities[i]);
            }
        }
    }
}