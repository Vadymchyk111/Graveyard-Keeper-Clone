using System;
using System.Collections.Generic;
using Collectable;
using UnityEngine;

namespace Player
{
    public class PlayerCollector : MonoBehaviour, ICollector
    {
        private List<ICollectable> _collectables = new();

        public void PickUp(ICollectable collectable)
        {
            collectable.DoCollect();
            _collectables.Add(collectable);
        }

        public void ThrowOut(ICollectable collectable)
        {
            collectable.UnCollect();
            _collectables.Remove(collectable);
        }

        private void OnTriggerEnter(Collider other)
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();

            if (collectable is null)
            {
                return; 
            }

            PickUp(collectable);
        }
    }
}