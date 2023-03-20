using System;

public interface IExtractable 
{
    event Action<ResourceEntity[]> OnExtracted;

    bool IsEmpty { get; set; }

    void StartExtracting(IExtracter extracter);
    void StopExtracting(IExtracter extracter);
}
