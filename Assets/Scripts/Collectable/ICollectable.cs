using System;
using PlayerInventory;
using PlayerInventory.Item;

namespace Collectable
{
   public interface ICollectable
   {
      event Action<bool> OnCollected;
      
      bool IsCollected { get; set; }
      Item Item { get; set; }
      
      void DoCollect();
      void UnCollect();
   }
}