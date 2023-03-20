using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerExtractor _playerExtractor;
    [SerializeField] private PlayerCollector _playerCollector;

    private void OnEnable()
    {
        //_playerExtractor.OnExtracted += FillInventoryCollactables;
    }
    /*
    private void FillInventoryCollactables(ICollectable[] collectables)
    {

        for()
        {
        _playerCollector.PickUp(collectable[i]);
        }

    }*/
}
