using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action OnDied;

    [SerializeField] private StarveSliderController _starveSliderController;

    private void Start()
    {
        _starveSliderController.StartStarveCalculation();
    }

    private void OnEnable()
    {
        _starveSliderController.OnStarveIsZero += DoDied;
    }

    private void OnDisable()
    {
        _starveSliderController.OnStarveIsZero -= DoDied;
    }

    public void RecoveryStarve(float starveValue)
    {
        _starveSliderController.RecoveryStarve(starveValue);
    }

    private void DoDied()
    {
        OnDied?.Invoke();
    }
}
