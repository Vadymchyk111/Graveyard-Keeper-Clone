using System;
using Collectable;
using Eatable;
using UnityEngine;

namespace Player
{
    public class PlayerEat : MonoBehaviour, IEater
    {
        private IEatable _eatable;
        public void Eat(IEatable eatable)
        {
            eatable.DoEating(() => _eatable = null);
        }

        private void OnTriggerEnter(Collider other)
        {
            _eatable = other.gameObject.GetComponent<IEatable>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (_eatable != null && Input.GetKeyDown(KeyCode.F))
            {
                Eat(_eatable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _eatable = null;
        }
    }
}