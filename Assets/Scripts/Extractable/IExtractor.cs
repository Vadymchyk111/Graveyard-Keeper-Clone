using System;
using System.Collections.Generic;
using PlayerInventory.ItemFolder;
using Resources.Generall;

namespace Extractable
{
    public interface IExtractor 
    {
        event Action<List<Item>> OnExtracted;
        event Action OnExtractHit;

        bool StartExtract(IExtractable extractable);
        void StopExtract();
        void ExtractionCompleted(ResourceEntity[] resourceEntities);
    }
}
