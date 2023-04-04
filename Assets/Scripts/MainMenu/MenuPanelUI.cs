using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelUI : MonoBehaviour
{
    public event Action OnYesButton;
    public event Action OnNoButton;
    
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private void OnEnable()
    {
        _yesButton.onClick.AddListener(OnYes);
        _noButton.onClick.AddListener(OnNo);
    }

    private void OnDisable()
    {
        _yesButton.onClick.RemoveListener(OnYes);
        _noButton.onClick.RemoveListener(OnNo);
    }

    private void OnYes()
    {
        OnYesButton?.Invoke();
    }

    private void OnNo()
    {
        OnNoButton?.Invoke();
    }
}
