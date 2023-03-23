using System;
using PlayerInventory;
using PlayerInventory.Item;
using Tools.Generall;
using UnityEngine;

namespace Tools
{
    public class Tool : MonoBehaviour, ITool
    {
        public event Action<bool> OnEquipped;
        
        [SerializeField] private Item _item;
        [SerializeField] private GameObject _toolBody;

        public string Id => _item.name;
        public bool IsEquipped { get; set; }
        
        public void Equip()
        {
            _toolBody.SetActive(true);
            OnEquipped?.Invoke(true);
        }

        public void UnEquip()
        {
            _toolBody.SetActive(false);
            OnEquipped?.Invoke(false);
        }
    }
}
