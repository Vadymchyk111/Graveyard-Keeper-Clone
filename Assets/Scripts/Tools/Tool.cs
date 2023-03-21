using System;
using System.Collections;
using System.Collections.Generic;
using PlayerInventory;
using UnityEngine;

public class Tool : MonoBehaviour, ITool
{
    [SerializeField] private Item _item;
    [SerializeField] private GameObject _toolBody;

    public string Id => _item.name;
    public bool IsEquiped { get; set; }

    public event Action<bool> OnEquiped;

    public void Equip()
    {
        _toolBody.SetActive(true);
    }

    public void UnEquip()
    {
        _toolBody.SetActive(false);
    }
}
