using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static event Action<GameObject> isDiedAction;
    [field: SerializeField, HideInInspector]
    public bool _isShields { get; set; } = false;
    [field: SerializeField, HideInInspector]
    public bool _isAdditionalSettings { get; set; } = false;
    [field: SerializeField, HideInInspector]
    public float _amountOfHealth { get; set; }
    [field: SerializeField, HideInInspector]
    public float _currentHealth { get; set; }
    [field: SerializeField, HideInInspector]
    public float _amountOfShields { get; set; }
    [field: SerializeField, HideInInspector]
    public float _currentShields { get; set; }
    [field: SerializeField, HideInInspector]
    public Slider _slider { get; set; }
    [field: SerializeField, HideInInspector]
    public bool _isDied { get; set; } = false;
    [field: SerializeField, HideInInspector]
    public Image _sliderFillImage { get; set; }
    [field: SerializeField, HideInInspector]
    public Image _sliderBottomImage { get; set; }
 
    private void Awake()
    {
        if (_isShields) 
        {
            _currentHealth = _amountOfHealth;
            _currentShields = SetParemeters(_currentShields, _amountOfShields, _slider, Color.green, Color.blue);
        }
        else _currentHealth = SetParemeters(_currentHealth, _amountOfHealth, _slider, Color.red, Color.green);
    }

    public void TakeDamage(float damage)
    {

        if (_isShields) 
        {
             _currentShields -= damage;
            _slider.value = _currentShields;

            if (_currentShields <= 0) 
            {
                SetParemeters(_currentHealth, _amountOfHealth, _slider, Color.red, Color.green);
                _isShields = false;
            }
        }
        else 
        {
            _currentHealth -= damage;
            _slider.value = _currentHealth;
        }

        if (_currentHealth <= 0) 
        {
            _isDied = true;
            isDiedAction?.Invoke(gameObject);
        }
    }

    public float SetParemeters(float current, float amount, Slider slider, Color fill, Color bottom) 
    {
        current = amount;
        slider.maxValue = amount;
        slider.value = amount;
        _sliderFillImage.color = fill;
        _sliderBottomImage.color = bottom;
        return current;
    }
}
