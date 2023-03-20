using System;
using System.Collections;
using System.Collections.Generic;
using Collectable;
using UnityEngine;

public class PlayerExtractor : MonoBehaviour, IExtracter
{
    public event Action<ICollectable[]> OnExtracted;

    public void StartExtract()
    {
        //TODO add check equiped axe
        //if axe equiped start animation
    }

    public void StopExtract()
    {
        //TODO add check equiped axe
        //if axe equiped stop animation
    }

    public void ExtractionCompleted(ResourceEntity[] resourceEntities)
    {
        //TODO resourceEntities to ICollectables[]
        //OnExtracted?.Invoke(ICollectables[]);
    }
}
