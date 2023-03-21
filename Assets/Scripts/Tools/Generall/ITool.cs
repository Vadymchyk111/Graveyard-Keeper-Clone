using System;

public interface ITool
{
    public event Action<bool> OnEquiped;

    public string Id { get; }
    public bool IsEquiped { get; set; }

    void Equip();
    void UnEquip();
}
