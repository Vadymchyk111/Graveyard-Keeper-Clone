using Collectable;
using UnityEngine;

namespace Player
{
    public class PlayerEat : MonoBehaviour, IEater
    {
        public void Eat(IEatable eatable)
        {
            eatable.DoEating();
            print("Im eating");
        }

        private void OnTriggerStay(Collider other)
        {
            IEatable eatable = other.gameObject.GetComponent<IEatable>();

            if (eatable is null || !Input.GetKeyDown(KeyCode.F))
            {
                return;
            }
            
            Eat(eatable);
        }
    }
}