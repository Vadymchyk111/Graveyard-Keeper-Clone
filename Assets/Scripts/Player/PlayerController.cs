using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using PlayerInventory;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerExtractor _playerExtractor;
    [SerializeField] private PlayerCollector _playerCollector;

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
}
