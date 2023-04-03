using System;
using System.Collections.Generic;
using PlayerInventory;
using Resources.Generall;

namespace ItemReceiver
{
    public interface IItemReceiver
    {
        event Action<bool> OnReceived;
        ResourceHolderData ResourceHolderData { get; }
        
        bool ReceiveItems(Inventory inventory);
    }
}