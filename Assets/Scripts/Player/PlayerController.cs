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
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private MoveByPhysicsController _moveByPhysicsController;

        public AnimationController AnimationController => _animationController;

        private void OnEnable()
        {
            _playerExtractor.OnExtracted += FillInventory;
            _moveByPhysicsController.OnPlayerMove += SetActiveMove;
        }

        private void OnDisable()
        {
            _playerExtractor.OnExtracted -= FillInventory;
            _moveByPhysicsController.OnPlayerMove -= SetActiveMove;
        }

        public bool CheckEquipedInstrument(IExtractable extractable)
        {
            return extractable.Tool.Name == _playerInventory.CurrentInstrument.Name;
        }

        private void FillInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                _playerCollector.PickUp(item);
            }
        }

        private void SetActiveMove(bool isActive)
        {
            _animationController.SetMove(isActive);
        }
    }
}
