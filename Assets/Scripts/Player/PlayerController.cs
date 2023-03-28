using System.Collections.Generic;
using Environment;
using Extractable;
using PlayerInventory;
using PlayerInventory.Item;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private PlayerExtractor _playerExtractor;
        [SerializeField] private PlayerCollector _playerCollector;
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private MoveByPhysicsController _moveByPhysicsController;

        public AnimationController AnimationController => _animationController;

        private void OnEnable()
        {
            _playerStats.OnDied += OnDied;
            _playerExtractor.OnExtracted += FillInventory;
            _moveByPhysicsController.OnPlayerMove += SetActiveMove;
        }

        private void OnDisable()
        {
            _playerStats.OnDied -= OnDied;
            _playerExtractor.OnExtracted -= FillInventory;
            _moveByPhysicsController.OnPlayerMove -= SetActiveMove;
        }

        public bool CheckEquipedInstrument(IExtractable extractable)
        {
            return _playerInventory.CurrentInstrument is not null && 
                   extractable.Tool.Name == _playerInventory.CurrentInstrument.Name;
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

        private void OnDied()
        {
            SceneManager.LoadScene(0);
        }
    }
}
