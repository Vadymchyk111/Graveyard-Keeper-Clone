using System;
using System.Collections.Generic;
using PlayerInventory.Item;
using Resourses.Generall;

namespace Extractable
{
    public interface IExtractor 
    {
        event Action<List<Item>> OnExtracted;

        void StartExtract(IExtractable extractable);
        void StopExtract();
        void ExtractionCompleted(ResourceEntity[] resourceEntities);
    }
}
