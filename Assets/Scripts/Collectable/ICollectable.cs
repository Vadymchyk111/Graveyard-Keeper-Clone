using System;

namespace Collectable
{
   public interface ICollectable
   {
      event Action<bool> OnCollected;
      
      bool IsCollected { get; set; }
      
      void DoCollect();
      void UnCollect();
   }
}