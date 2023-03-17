using System;

namespace Collectable
{
    public interface IEatable
    {
        void DoEating(Action onEatingCompleded);
    }
}