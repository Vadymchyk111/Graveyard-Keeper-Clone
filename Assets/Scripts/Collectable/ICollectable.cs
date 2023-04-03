using System;
using PlayerInventory;
using PlayerInventory.ItemFolder;

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