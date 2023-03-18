using System;
using PlayerInventory;

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