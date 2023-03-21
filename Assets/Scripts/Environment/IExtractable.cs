using System;
using Resourses.Generall;

namespace Environment
{
    public interface IExtractable
    {
        event Action<ResourceEntity[]> OnExtracted;
        bool IsEmpty { get; set; }

        void StartExtracting(IExtractor extractor);
        void StopExtracting(IExtractor extractor);
    }
}
