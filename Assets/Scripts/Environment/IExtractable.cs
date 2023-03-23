using System;
using PlayerInventory;
using PlayerInventory.Item;
using Resourses.Generall;

namespace Environment
{
    public interface IExtractable
    {
        event Action<ResourceEntity[]> OnExtracted;
        bool IsEmpty { get; set; }
        Item Tool { get; }

        void StartExtracting(IExtractor extractor);
        void StopExtracting(IExtractor extractor);
    }
}
