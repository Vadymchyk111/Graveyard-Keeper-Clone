using System;
using Collectable;

public interface IExtracter 
{
    event Action<ICollectable[]> OnExtracted;

    void StartExtract();
    void StopExtract();
    void ExtractionCompleted(ResourceEntity[] resourceEntities);
}
