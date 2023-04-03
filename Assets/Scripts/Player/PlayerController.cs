using System;
using System.Collections.Generic;
using Environment;
using Extractable;
using PlayerInventory;
using PlayerInventory.ItemFolder;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private PlayerEat _playerEat;
        [SerializeField] private PlayerExtractor _playerExtractor;
        [SerializeField] private PlayerCollector _playerCollector;
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private MoveByPhysicsController _moveByPhysicsController;
        [SerializeField] private Inventory _inventory;

        public AnimationController AnimationController => _animationController;
        public Inventory Inventory => _inventory;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            _playerEat.OnRecoveryStarve += RecoveryStarve;
            _playerStats.OnDied += OnDied;
            _playerExtractor.OnExtracted += FillInventory;
            _moveByPhysicsController.OnPlayerMove += SetActiveMove;
            _animationController.OnMiningHit += _playerExtractor.HitExtract;
        }

        private void OnDisable()
        {
            _playerEat.OnRecoveryStarve -= RecoveryStarve;
            _playerStats.OnDied -= OnDied;
            _playerExtractor.OnExtracted -= FillInventory;
            _moveByPhysicsController.OnPlayerMove -= SetActiveMove;
            _animationController.OnMiningHit -= _playerExtractor.HitExtract;
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

        private void RecoveryStarve(float recoveryValue)
        {
            _playerStats.RecoveryStarve(recoveryValue);
        }

        private void Init()
        {
            _playerCollector.Init(_inventory);
            _playerEat.Init(_inventory);
            _playerInventory.Init(_inventory);
        }
    }
}
