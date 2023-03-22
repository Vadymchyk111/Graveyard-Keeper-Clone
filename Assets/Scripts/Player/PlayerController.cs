using System.Collections.Generic;
using Environment;
using PlayerInventory;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerExtractor _playerExtractor;
        [SerializeField] private PlayerCollector _playerCollector;
        [SerializeField] private PlayerInventory _playerInventory;

        private void OnEnable()
        {
            _playerExtractor.OnExtracted += FillInventory;
        }

        private void OnDisable()
        {
            _playerExtractor.OnExtracted -= FillInventory;
        }

        private void FillInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                _playerCollector.PickUp(item);
            }
        }

        public bool CheckEquipedInstrument(IExtractable extractable)
        {
            return extractable.InstrumentToDestroy.Name == _playerInventory.CurrentInstrument.Name;
        }
    }
}
