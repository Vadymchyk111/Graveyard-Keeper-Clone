namespace Collectable
{
    public interface ICollector
    {
        void PickUp(ICollectable collectable);
        void ThrowOut(ICollectable collectable);
    }
}