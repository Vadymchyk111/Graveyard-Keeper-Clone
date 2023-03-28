using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarveSliderController : MonoBehaviour
{
    public event Action OnStarveIsZero;

    [SerializeField] private Slider _slider;
    [SerializeField] private float _starveUpdateTickInSeconds = 0.1f;
    [SerializeField] private float _starveDectreaseValueInTick = 0.01f;

    private Coroutine _starveCoroutine;
    private WaitForSeconds _starveUpdateTickInSecondsDelay;

    private void Awake()
    {
        _starveUpdateTickInSecondsDelay = new WaitForSeconds(_starveUpdateTickInSeconds);
    }

    public void FullRecoveryStarve()
    {
        RecoveryStarve(1);
    }

    public void RecoveryStarve(float value)
    {
        _slider.value += value;
    }

    public void StartStarveCalculation()
    {
        StopStarveCalculation();

        _starveCoroutine = StartCoroutine(StarveCoroutine());
    }

    public void StopStarveCalculation()
    {
        if (_starveCoroutine != null)
        {
            StopCoroutine(_starveCoroutine);
        }
    }

    private IEnumerator StarveCoroutine()
    {
        while(_slider.value > 0)
        {
            _slider.value -= _starveDectreaseValueInTick;
            yield return _starveUpdateTickInSecondsDelay;
        }

        OnStarveIsZero?.Invoke();
    }
}
