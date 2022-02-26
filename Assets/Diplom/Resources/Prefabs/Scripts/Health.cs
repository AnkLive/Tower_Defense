using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    public static event Action<GameObject> isDiedAction;
    public abstract bool _isShields { get; set; }
    public abstract float _amountOfHealth { get; set; }
    public abstract float _currentHealth { get; set; }
    public abstract float _amountOfShields { get; set; }
    public abstract float _currentShields { get; set; }
    public abstract Slider _slider { get; set; }
    public abstract Image _sliderTopImage { get; set; }
    public abstract Image _sliderBottomImage { get; set; }
    public abstract bool _isDied { get; set; }

    public virtual void TakeDamage(float damage)
    {

        if (_isShields) 
        {
            SetCurrentParameters(_currentShields, damage, _slider);

            if (_currentShields <= 0) 
            {
                SetParemetersHealthBar(_amountOfHealth, _slider, Color.red, Color.green);
                _isShields = false;
            }
        }
        else 
        {
            SetCurrentParameters(_currentHealth, damage, _slider);
        }

        if (_currentHealth <= 0) 
        {
            _isDied = true;
            isDiedAction?.Invoke(gameObject);
        }
    }

    public virtual float SetParemetersHealthBar(float amount, Slider slider, Color topColor, Color bottomColor) 
    {
        var current = amount;
        slider.maxValue = amount;
        slider.value = amount;
        _sliderTopImage.color = topColor;
        _sliderBottomImage.color = bottomColor;
        return current;
    }

    public void SetCurrentParameters(float currentParameter, float inputParameter, Slider slider) 
    {
        currentParameter -= inputParameter;
        slider.value = currentParameter;
    }
}
