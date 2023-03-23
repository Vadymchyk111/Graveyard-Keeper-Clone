using System;
using UnityEngine;
using UnityEngine.UI;
using Values.ScriptableObjects;

namespace Crafting.Recipy.UI.Values
{
    public class ValueTextUpdater : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectInt _value;
        [SerializeField] private Text _text;

        private void Start()
        {
            _text.text = _value.Value.Value.ToString();
        }

        private void OnEnable()
        {
            _value.OnValueChanged += UpdateText;
        }

        private void OnDisable()
        {
            _value.OnValueChanged -= UpdateText;
        }

        private void UpdateText(int value, int minValue, int maxValue)
        {
            _text.text = value.ToString();
        }
    }
}
