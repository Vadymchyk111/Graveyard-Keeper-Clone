using System;
using PlayerInventory;
using Resourses.Generall;

namespace Environment
{
    public interface IExtractable
    {
        event Action<ResourceEntity[]> OnExtracted;
        bool IsEmpty { get; set; }
        Item InstrumentToDestroy { get; }

        void StartExtracting(IExtractor extractor);
        void StopExtracting(IExtractor extractor);
    }
}
