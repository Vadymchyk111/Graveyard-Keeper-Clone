using System;

namespace Eatable
{
    public interface IEatable
    {
        void DoEating(Action onEatingCompleded);
    }
}