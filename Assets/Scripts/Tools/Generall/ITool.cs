using System;

namespace Tools.Generall
{
    public interface ITool
    {
        public event Action<bool> OnEquipped;

        public string Id { get; }
        public bool IsEquipped { get; set; }

        void Equip();
        void UnEquip();
    }
}
