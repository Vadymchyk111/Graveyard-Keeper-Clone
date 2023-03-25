using System;
using System.Collections.Generic;
using PlayerInventory;
using PlayerInventory.Item;
using Resourses.Generall;

namespace ItemReceiver
{
    public interface IItemReceiver
    {
        event Action<bool> OnReceived;
        ResourceEntity[] ResourceEntities { get; }
        
        bool ReceiveItems(Inventory inventory);
    }
}