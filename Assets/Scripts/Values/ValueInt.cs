using UnityEngine;

namespace Values
{
    [System.Serializable]
    public struct ValueInt
    {
        [SerializeField] private string _name;
        [SerializeField] private int _value;
        
        public string Name => _name;
        public int Value => _value;

        public int RestoreValue()
        {
            _value = PlayerPrefs.GetInt(Name);
            return _value;
        }

        public void ChangeValue(int newValue)
        {
            _value = newValue;
            PlayerPrefs.SetInt(Name, newValue);
            PlayerPrefs.Save();
        }
    }
}
