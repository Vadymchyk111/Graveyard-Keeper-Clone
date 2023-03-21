using System;
using System.Collections.Generic;
using PlayerInventory;
using Resourses.Generall;

namespace Environment
{
    public interface IExtractor 
    {
        event Action<List<Item>> OnExtracted;

        void StartExtract();
        void StopExtract();
        void ExtractionCompleted(ResourceEntity[] resourceEntities);
    }
}
