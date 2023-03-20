using System;
using System.Collections;
using System.Collections.Generic;
using Collectable;
using UnityEngine;

public class TreeController : MonoBehaviour, IExtractable
{
    [SerializeField] private DestructableResourceHolderData _destructableResourceHolderData;

    public bool IsEmpty { get; set; }

    public event Action<ResourceEntity[]> OnExtracted;

    public void StartExtracting(IExtracter extracter)
    {
        extracter.StartExtract();
        //TODO start coroutine and decrease HP from DestructableResourceHolderData
        //when HP == 0 send event OnExtracted
        //call extracter.ExtractionCompleted(_destructableResourceHolderData.ResourceEntities)
    }

    public void StopExtracting(IExtracter extracter)
    {
        extracter.StopExtract();
    }

    void OnTriggerEnter(Collider col)
    {
        //TODO replace check on Tag Player
        IExtracter extracter = col.GetComponent<IExtracter>();

        if(extracter == null)
        {
            return;
        }

        StartExtracting(extracter);
    }

    void OnTriggerExit(Collider col)
    {
        IExtracter extracter = col.GetComponent<IExtracter>();

        if (extracter == null)
        {
            return;
        }

        StopExtracting(extracter);
    }
}
