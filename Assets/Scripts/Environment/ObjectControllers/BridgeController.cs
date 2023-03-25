using System;
using ReceiverObjects;
using UnityEngine;

namespace Environment.ObjectControllers
{
    public class BridgeController : MonoBehaviour
    {
        [SerializeField] private ReceiverBase _receiver;
        [SerializeField] private GameObject _destroyedBridge;
        [SerializeField] private GameObject _fixedBridge;

        private void OnEnable()
        {
            _receiver.OnReceived += FixBridge;
        }

        private void OnDisable()
        {
            _receiver.OnReceived -= FixBridge;
        }

        private void FixBridge(bool isFixed)
        {
            if (!isFixed)
            {
                return;
            }
            
            _destroyedBridge.SetActive(false);
            _fixedBridge.SetActive(true);
        }
    }
}